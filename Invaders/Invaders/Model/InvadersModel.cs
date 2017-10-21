using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders.Model
{
    using Windows.Foundation;

    class InvadersModel
    {
        public readonly static Size PlayAreaSize = new Size(400, 300);
        public const int MaximumPlayerShots = 3;
        public const int InitialStarCount = 50;

        private Player _player;
        
        private readonly List<Invader> _invaders = new List<Invader>();
        private readonly List<Shot> _playerShots = new List<Shot>();
        private readonly List<Shot> _invaderShots = new List<Shot>();
        private readonly List<Point> _stars = new List<Point>();

        private readonly Random _random = new Random();

        public int Score { get; private set; }
        public int Wave { get; private set; }
        public int Lives { get; private set; }

        public bool GameOver { get; private set; }

        private DateTime? _playerDied = null;
        public bool PlayerDying { get { return _playerDied.HasValue; } }

        private Direction _invaderDirection = Direction.Left;
        private bool _justMovedDown = false;

        private DateTime _lastUpdated = DateTime.MinValue;

        public InvadersModel()
        {
            EndGame();
        }

        public void EndGame()
        {
            GameOver = true;
        }

        public void StartGame()
        {
            GameOver = false;

            foreach (Invader invader in _invaders)
                OnShipChanged(invader, true);
            _invaders.Clear();

            foreach (Shot shot in _playerShots)
                OnShotMoved(shot, true);
            _playerShots.Clear();
            _invaderShots.Clear();

            foreach (Point star in _stars)
                OnStarChanged(star, true);
            _stars.Clear();
            for (int i = 0; i < InitialStarCount; i++)
                AddAStar();

            _player = new Player();
            OnShipChanged(_player, false);

            Lives = 2;
            Wave = 0;

            NextWave();
        }

        public void FireShot()
        {
            if (GameOver) return;

            var playerShots =
                from Shot shot in _playerShots
                where shot.Direction == Direction.Up
                select shot;

            if (playerShots.Count() < MaximumPlayerShots)
            {
                Point shotLocation = new Point(_player.Location.X + _player.Area.Width / 2, _player.Location.Y);
                Shot shot = new Shot(shotLocation, Direction.Up);
                _playerShots.Add(shot);
                OnShotMoved(shot, false);
            }
        }

        public void Twinkle()
        {
            if ((_random.Next(2) == 0) && _stars.Count > ((int)InitialStarCount * .75))
                RemoveAStar();
            else if (_stars.Count < ((int)InitialStarCount * 1.5))
                AddAStar();
        }

        private void RemoveAStar()
        {
            if (_stars.Count <= 0) return;
            int starIndex = _random.Next(_stars.Count);
            OnStarChanged(_stars[starIndex], true);
            _stars.RemoveAt(starIndex);
        }

        private void AddAStar()
        {
            Point point = new Point(_random.Next((int)PlayAreaSize.Width), _random.Next(20, (int)PlayAreaSize.Height) - 20);
            if (!_stars.Contains(point))
            {
                _stars.Add(point);
                OnStarChanged(point, false);
            }
        }

        public void MovePlayer(Direction direction)
        {
            if (_playerDied.HasValue) return;
            _player.Move(direction);
            OnShipChanged(_player, false);
        }

        public void Update(bool paused)
        {
            if (!paused)
            {
                if (_invaders.Count() == 0) NextWave();

                if (!_playerDied.HasValue)
                {
                    MoveInvaders();
                    MoveShots();
                    ReturnFire();
                    CheckForInvaderCollisions();
                    CheckForPlayerCollisions();
                }
                else if (_playerDied.HasValue && (DateTime.Now - _playerDied > TimeSpan.FromSeconds(2.5)))
                {
                    _playerDied = null;
                    OnShipChanged(_player, false);
                }
            }
            Twinkle();
        }

        private void MoveShots()
        {
            foreach (Shot shot in _playerShots)
            {
                shot.Move();
                OnShotMoved(shot, false);
            }

            var outOfBounds =
                from shot in _playerShots
                where (shot.Location.Y < 10 || shot.Location.Y > PlayAreaSize.Height - 10)
                select shot;

            foreach (Shot shot in outOfBounds.ToList())
            {
                _playerShots.Remove(shot);
                OnShotMoved(shot, true);
            }
        }

        private void NextWave()
        {
            Wave++;
            _invaders.Clear();
            for (int row = 0; row <= 5; row++)
                for (int column = 0; column < 11; column++)
                {
                    Point location = new Point(column * Invader.InvaderSize.Width * 1.4, row * Invader.InvaderSize.Height * 1.4);
                    Invader invader;
                    switch (row)
                    {
                        case 0:
                            invader = new Invader(InvaderType.Spaceship, location, 50);
                            break;
                        case 1:
                            invader = new Invader(InvaderType.Bug, location, 40);
                            break;
                        case 2:
                            invader = new Invader(InvaderType.Saucer, location, 30);
                            break;
                        case 3:
                            invader = new Invader(InvaderType.Satellite, location, 20);
                            break;
                        default:
                            invader = new Invader(InvaderType.Star, location, 10);
                            break;
                    }
                    _invaders.Add(invader);
                    OnShipChanged(invader, false);
                }
        }


        private void CheckForPlayerCollisions() 
        {
            bool removeAllShots = false;
            var result = from invader in _invaders where invader.Area.Bottom > _player.Area.Top + _player.Size.Height select invader;
            if (result.Count() > 0)
                EndGame();

            var shotsHit =
                from shot in _playerShots
                where shot.Direction == Direction.Down && _player.Area.Contains(shot.Location)
                select shot;
            if (shotsHit.Count() > 0)
            {
                Lives--;
                if (Lives >= 0)
                {
                    _playerDied = DateTime.Now;
                    OnShipChanged(_player, true);
                    removeAllShots = true;
                }
                else
                    EndGame();
            }
            if (removeAllShots)
                foreach (Shot shot in _playerShots.ToList())
                {
                    _playerShots.Remove(shot);
                    OnShotMoved(shot, true);
                }
        }

        private void CheckForInvaderCollisions() 
        {
            List<Shot> shotsHit = new List<Shot>();
            List<Invader> invadersKilled = new List<Invader>();
            foreach (Shot shot in _playerShots)
            {
                var result = from invader in _invaders
                             where invader.Area.Contains(shot.Location) == true && shot.Direction == Direction.Up
                             select new {InvaderKilled = invader, ShotHit = shot};
                if (result.Count() > 0)
                {
                    foreach (var o in result)
                    {
                        shotsHit.Add(o.ShotHit);
                        invadersKilled.Add(o.InvaderKilled);
                    }
                }
            }
            foreach (Invader invader in invadersKilled)
            {
                Score += invader.Score;
                _invaders.Remove(invader);
                OnShipChanged(invader, true);
            }
            foreach (Shot shot in shotsHit)
            {
                _playerShots.Remove(shot);
                OnShotMoved(shot, true);
            }
        }

        private void MoveInvaders() 
        {
            double millisecondsBetweenMovements = Math.Min(10 - Wave, 1) * (2 * _invaders.Count());
            if (DateTime.Now - _lastUpdated > TimeSpan.FromMilliseconds(millisecondsBetweenMovements))
            {
                _lastUpdated = DateTime.Now;

                var invadersTouchingLeftBoundary = from invader in _invaders where invader.Area.Left < Invader.HorizontalInterval select invader;
                var invadersTouchingRightBoundary = from invader in _invaders where invader.Area.Right > PlayAreaSize.Width - (Invader.HorizontalInterval * 2) select invader;

                if (!_justMovedDown)
                {
                    if (invadersTouchingLeftBoundary.Count() > 0)
                    {
                        foreach (Invader invader in _invaders)
                        {
                            invader.Move(Direction.Down);
                            OnShipChanged(invader, false);
                        }
                        _invaderDirection = Direction.Right;
                    }
                    else if (invadersTouchingRightBoundary.Count() > 0)
                    {
                        foreach (Invader invader in _invaders)
                        {
                            invader.Move(Direction.Down);
                            OnShipChanged(invader, false);
                        }
                        _invaderDirection = Direction.Left;
                    }
                    _justMovedDown = true;
                }
                else
                {
                    _justMovedDown = false;
                    foreach (Invader invader in _invaders)
                    {
                        invader.Move(_invaderDirection);
                        OnShipChanged(invader, false);
                    }
                }
            }
        }

        private void ReturnFire() 
        {
            if (_invaders.Count() == 0) return;
            
            var invaderShots =
                from Shot shot in _playerShots
                where shot.Direction == Direction.Down
                select shot;

            if (invaderShots.Count() > Wave + 1 || _random.Next(10) < 10 - Wave)
                return;

            var result = 
                from invader in _invaders 
                group invader by invader.Area.X into invaderGroup 
                orderby invaderGroup.Key descending 
                select invaderGroup;

            var randomGroup = result.ElementAt(_random.Next(result.ToList().Count()));
            var bottomInvader = randomGroup.Last();

            Point shotLocation = new Point(bottomInvader.Area.X + bottomInvader.Area.Width / 2, bottomInvader.Area.Bottom + 2);
            Shot invaderShot = new Shot(shotLocation, Direction.Down);
            _playerShots.Add(invaderShot);
            OnShotMoved(invaderShot, false);
        }

        internal void UpdateAllShipsAndStars()
        {
            foreach (Shot shot in _playerShots)
                OnShotMoved(shot, false);
            foreach (Invader ship in _invaders)
                OnShipChanged(ship, false);
            OnShipChanged(_player, false);
            foreach (Point star in _stars)
                OnStarChanged(star, false);
        }

        
        public event EventHandler<ShipChangedEventArgs> ShipChanged;

        protected void OnShipChanged(Ship shipUpdated, bool killed)
        {
            EventHandler<ShipChangedEventArgs> shipChanged = ShipChanged;
            if (shipChanged != null)
                shipChanged(this, new ShipChangedEventArgs(shipUpdated, killed));
        }

        public event EventHandler<ShotMovedEventArgs> ShotMoved;

        protected void OnShotMoved(Shot shot, bool disappeared)
        {
            EventHandler<ShotMovedEventArgs> shotMoved = ShotMoved;
            if (shotMoved != null)
                shotMoved(this, new ShotMovedEventArgs(shot, disappeared));
        }

        public event EventHandler<StarChangedEventArgs> StarChanged;

        protected void OnStarChanged(Point point, bool disappeared)
        {
            EventHandler<StarChangedEventArgs> starChanged = StarChanged;
            if (starChanged != null)
                starChanged(this, new StarChangedEventArgs(point, disappeared));
        }
    }
}
