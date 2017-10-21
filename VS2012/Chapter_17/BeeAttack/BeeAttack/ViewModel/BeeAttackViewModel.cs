using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeAttack.ViewModel
{
    using View;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    class BeeAttackViewModel : INotifyPropertyChanged
    {
        public INotifyCollectionChanged BeeControls { get { return _beeControls; } }
        private readonly ObservableCollection<BeeControl> _beeControls
                                                                = new ObservableCollection<BeeControl>();

        public Thickness FlowerMargin { get; private set; }
        public Thickness HiveMargin { get; private set; }
        public int MissesLeft { get { return _model.MissesLeft; } }
        public int Score { get { return _model.Score; } }
        public Visibility GameOver { get; private set; }

        private Size _beeSize;
        private readonly Model.BeeAttackModel _model = new Model.BeeAttackModel();
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private double _lastX;
        private Size _playAreaSize { get; set; }
        private Size _hiveSize { get; set; }
        private Size _flowerSize { get; set; }

        public BeeAttackViewModel()
        {
            _model.Missed += MissedEventHandler;
            _model.GameOver += GameOverEventHandler;
            _model.PlayerScored += PlayerScoredEventHandler;

            _timer.Tick += HiveTimerTick;

            GameOver = Visibility.Visible;
            OnPropertyChanged("GameOver");
        }

        public void StartGame(Size flowerSize, Size hiveSize, Size playAreaSize)
        {
            _flowerSize = flowerSize;
            _hiveSize = hiveSize;
            _playAreaSize = playAreaSize;
            _beeSize = new Size(playAreaSize.Width / 10, playAreaSize.Width / 10);
            _model.StartGame(flowerSize.Width, _beeSize.Width, playAreaSize.Width, hiveSize.Width);
            OnPropertyChanged("MissesLeft");

            _timer.Interval = _model.TimeBetweenBees;
            _timer.Start();

            GameOver = Visibility.Collapsed;
            OnPropertyChanged("GameOver");
        }

        public void ManipulationDelta(double newX)
        {
            newX = _lastX + newX * 1.5;
            if (newX >= 0 && newX < (_playAreaSize.Width - _flowerSize.Width))
            {
                _model.MoveFlower(newX);
                FlowerMargin = new Thickness(newX, 0, 0, 0);
                OnPropertyChanged("FlowerMargin");
                _lastX = newX;
            }
        }

        private void GameOverEventHandler(object sender, EventArgs e)
        {
            _timer.Stop();
            GameOver = Visibility.Visible;
            OnPropertyChanged("GameOver");
        }

        private void MissedEventHandler(object sender, EventArgs e)
        {
            OnPropertyChanged("MissesLeft");
        }

        void HiveTimerTick(object sender, EventArgs e)
        {
            if (_playAreaSize.Width <= 0) return;

            double x = _model.NextHiveLocation();

            HiveMargin = new Thickness(x, 0, 0, 0);
            OnPropertyChanged("HiveMargin");

            BeeControl bee = new BeeControl(x + _hiveSize.Width / 2, 0,
                                            _playAreaSize.Height + _flowerSize.Height / 3, BeeLanded);
            bee.Width = _beeSize.Width;
            bee.Height = _beeSize.Height;
            _beeControls.Add(bee);
        }

        private void BeeLanded(object sender, EventArgs e)
        {
            BeeControl landedBee = null;
            foreach (BeeControl sprite in _beeControls)
            {
                if (sprite.FallingStoryboard == sender)
                    landedBee = sprite;
            }
            _model.BeeLanded(Canvas.GetLeft(landedBee));
            if (landedBee != null) _beeControls.Remove(landedBee);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PlayerScoredEventHandler(object sender, EventArgs e)
        {
            OnPropertyChanged("Score");
            _timer.Interval = _model.TimeBetweenBees;
        }
    }
}
