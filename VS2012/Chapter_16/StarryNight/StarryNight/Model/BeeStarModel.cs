using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNight.Model
{
    using Windows.Foundation;

    class BeeStarModel
    {
        public static readonly Size StarSize = new Size(150, 100);

        private readonly Dictionary<Bee, Point> _bees = new Dictionary<Bee, Point>();
        private readonly Dictionary<Star, Point> _stars = new Dictionary<Star, Point>();
        private Random _random = new Random();

        public BeeStarModel()
        {
            _playAreaSize = Size.Empty;
        }

        public void Update()
        {
            MoveOneBee();
            AddOrRemoveAStar();
        }

        private static bool RectsOverlap(Rect r1, Rect r2)
        {
            r1.Intersect(r2);
            if (r1.Width > 0 || r1.Height > 0)
                return true;
            return false;
        }

        private Size _playAreaSize;
        public Size PlayAreaSize
        {
            get { return _playAreaSize; }
            set
            {
                _playAreaSize = value;
                CreateBees();
                CreateStars();
            }
        }

        private void CreateBees()
        {
            if (PlayAreaSize == Size.Empty) return;

            if (_bees.Count() > 0)
            {
                List<Bee> allBees = _bees.Keys.ToList();
                foreach (Bee bee in allBees)
                    MoveOneBee(bee);
            }
            else
            {
                int beeCount = _random.Next(5, 16);
                for (int i = 0; i < beeCount; i++)
                {
                    int s = _random.Next(40, 151);
                    Size beeSize = new Size(s, s);
                    Point newLocation = FindNonOverlappingPoint(beeSize);
                    Bee newBee = new Bee(newLocation, beeSize);
                    _bees[newBee] = new Point(newLocation.X, newLocation.Y);
                    OnBeeMoved(newBee, newLocation.X, newLocation.Y);
                }
            }
        }

        private void CreateStars()
        {
            if (PlayAreaSize == Size.Empty) return;

            if (_stars.Count > 0)
            {
                foreach (Star star in _stars.Keys)
                {
                    star.Location = FindNonOverlappingPoint(StarSize);
                    OnStarChanged(star, false);
                }
            }
            else
            {
                int starCount = _random.Next(5, 11);
                for (int i = 0; i < starCount; i++)
                    CreateAStar();
            }
        }

        private void CreateAStar()
        {
            Point newLocation = FindNonOverlappingPoint(StarSize);
            Star newStar = new Star(newLocation);
            _stars[newStar] = new Point(newLocation.X, newLocation.Y);
            OnStarChanged(newStar, false);
        }

        private Point FindNonOverlappingPoint(Size size)
        {
            Rect newRect;
            bool noOverlap = false;
            int count = 0;
            while (!noOverlap)
            {
                newRect = new Rect(_random.Next((int)PlayAreaSize.Width - 150),
                    _random.Next((int)PlayAreaSize.Height - 150),
                    size.Width, size.Height);

                var overlappingBees =
                    from bee in _bees.Keys
                    where RectsOverlap(bee.Position, newRect)
                    select bee;

                var overlappingStars =
                    from star in _stars.Keys
                    where RectsOverlap(
                        new Rect(star.Location.X, star.Location.Y, StarSize.Width, StarSize.Height),
                        newRect)
                    select star;

                if ((overlappingBees.Count() + overlappingStars.Count() == 0) || (count++ > 1000))
                    noOverlap = true;
            }
            return new Point(newRect.X, newRect.Y);
        }

        private void MoveOneBee(Bee bee = null)
        {
            if (_bees.Keys.Count() == 0) return;
            if (bee == null)
            {
                List<Bee> bees = _bees.Keys.ToList();
                bee = bees[_random.Next(bees.Count)];
            }
            bee.Location = FindNonOverlappingPoint(bee.Size);
            _bees[bee] = bee.Location;
            OnBeeMoved(bee, bee.Location.X, bee.Location.Y);
        }

        private void AddOrRemoveAStar()
        {
            if (((_random.Next(2) == 0) || (_stars.Count <= 5)) && (_stars.Count < 20))
                CreateAStar();
            else
            {
                Star starToRemove = _stars.Keys.ToList()[_random.Next(_stars.Count)];
                _stars.Remove(starToRemove);
                OnStarChanged(starToRemove, true);
            }
        }

        public event EventHandler<BeeMovedEventArgs> BeeMoved;

        private void OnBeeMoved(Bee beeThatMoved, double x, double y)
        {
            EventHandler<BeeMovedEventArgs> beeMoved = BeeMoved;
            if (beeMoved != null)
            {
                beeMoved(this, new BeeMovedEventArgs(beeThatMoved, x, y));
            }
        }

        public event EventHandler<StarChangedEventArgs> StarChanged;

        private void OnStarChanged(Star starThatChanged, bool removed)
        {
            EventHandler<StarChangedEventArgs> starChanged = StarChanged;
            if (starChanged != null)
            {
                starChanged(this, new StarChangedEventArgs(starThatChanged, removed));
            }
        }
    }
}
