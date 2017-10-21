using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeAttack.Model
{
    using Windows.Foundation;

    class BeeAttackModel
    {
        public int MissesLeft { get; private set; }
        public int Score { get; private set; }
        public TimeSpan TimeBetweenBees
        {
            get
            {
                double milliseconds = 500;
                milliseconds = Math.Max(milliseconds - Score * 2.5, 100);
                return TimeSpan.FromMilliseconds(milliseconds);
            }
        }

        private double _flowerWidth;
        private double _beeWidth;
        private double _flowerLeft;
        private double _playAreaWidth;
        private double _hiveWidth;
        private double _lastHiveLocation;
        private bool _gameOver;
        private readonly Random _random = new Random();

        public void StartGame(double flowerWidth, double beeWidth, double playAreaWidth, double hiveWidth)
        {
            _flowerWidth = flowerWidth;
            _beeWidth = beeWidth;
            _playAreaWidth = playAreaWidth;
            _hiveWidth = hiveWidth;
            _lastHiveLocation = playAreaWidth / 2;
            MissesLeft = 5;
            Score = 0;
            _gameOver = false;
            OnPlayerScored();
        }

        public void MoveFlower(double flowerLeft)
        {
            _flowerLeft = flowerLeft;
        }

        public void BeeLanded(double beeLeft)
        {
            if ((beeLeft < _flowerLeft) || (beeLeft > _flowerLeft + _flowerWidth))
            {
                if (MissesLeft > 0)
                {
                    MissesLeft--;
                    OnMissed();
                }
                else
                {
                    _gameOver = true;
                    OnGameOver();
                }
            }
            else if (!_gameOver)
            {
                Score++;
                OnPlayerScored();
            }
        }

        public double NextHiveLocation()
        {
            double delta = 10 + Math.Max(1, Score * .5);

            if (_lastHiveLocation <= _hiveWidth * 2)
                _lastHiveLocation += delta;
            else if (_lastHiveLocation >= _playAreaWidth - _hiveWidth * 2)
                _lastHiveLocation -= delta;
            else
                _lastHiveLocation += delta * (_random.Next(2) == 0 ? 1 : -1);


            return _lastHiveLocation;
        }

        public EventHandler Missed;
        private void OnMissed()
        {
            EventHandler missed = Missed;
            if (missed != null)
                missed(this, new EventArgs());
        }

        public EventHandler GameOver;
        private void OnGameOver()
        {
            EventHandler gameOver = GameOver;
            if (gameOver != null)
                gameOver(this, new EventArgs());
        }

        public EventHandler PlayerScored;
        private void OnPlayerScored()
        {
            EventHandler playerScored = PlayerScored;
            if (playerScored != null)
                playerScored(this, new EventArgs());
        }
    }
}
