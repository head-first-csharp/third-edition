using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNight.ViewModel
{
    using View;
    using Model;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows;
    using DispatcherTimer = System.Windows.Threading.DispatcherTimer;
    using UIElement = System.Windows.UIElement;

    class BeeStarViewModel
    {
        private readonly ObservableCollection<UIElement>
                    _sprites = new ObservableCollection<UIElement>();
        public INotifyCollectionChanged Sprites { get { return _sprites; } }

        private readonly Dictionary<Star, StarControl> _stars = new Dictionary<Star, StarControl>();
        private readonly List<StarControl> _fadedStars = new List<StarControl>();

        private BeeStarModel _model = new BeeStarModel();

        private readonly Dictionary<Bee, AnimatedImage> _bees
                                              = new Dictionary<Bee, AnimatedImage>();

        private DispatcherTimer _timer = new DispatcherTimer();

        public Size PlayAreaSize
        {
            get { return _model.PlayAreaSize; }
            set { _model.PlayAreaSize = value; }
        }

        public BeeStarViewModel()
        {
            _model.BeeMoved += BeeMovedHandler;
            _model.StarChanged += StarChangedHandler;

            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            foreach (StarControl starControl in _fadedStars)
                _sprites.Remove(starControl);

            _model.Update();
        }

        void BeeMovedHandler(object sender, BeeMovedEventArgs e)
        {
            if (!_bees.ContainsKey(e.BeeThatMoved))
            {
                AnimatedImage beeControl = BeeStarHelper.BeeFactory(
                            e.BeeThatMoved.Width, e.BeeThatMoved.Height, TimeSpan.FromMilliseconds(20));
                BeeStarHelper.SetCanvasLocation(beeControl, e.X, e.Y);
                _bees[e.BeeThatMoved] = beeControl;
                _sprites.Add(beeControl);
            }
            else
            {
                AnimatedImage beeControl = _bees[e.BeeThatMoved];
                BeeStarHelper.MoveElementOnCanvas(beeControl, e.X, e.Y);
            }
        }

        void StarChangedHandler(object sender, StarChangedEventArgs e)
        {
            if (e.Removed)
            {
                StarControl starControl = _stars[e.StarThatChanged];
                _stars.Remove(e.StarThatChanged);
                _fadedStars.Add(starControl);
                starControl.FadeOut();
            }
            else
            {
                StarControl newStar;
                if (_stars.ContainsKey(e.StarThatChanged))
                    newStar = _stars[e.StarThatChanged];
                else
                {
                    newStar = new StarControl();
                    _stars[e.StarThatChanged] = newStar;
                    newStar.FadeIn();
                    BeeStarHelper.SendToBack(newStar);
                    _sprites.Add(newStar);
                }
                BeeStarHelper.SetCanvasLocation(
                           newStar, e.StarThatChanged.Location.X, e.StarThatChanged.Location.Y);
            }
        }
    }
}
