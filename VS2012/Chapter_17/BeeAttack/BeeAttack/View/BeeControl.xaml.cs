using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BeeAttack.View
{
    using Microsoft.Phone.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;

    public sealed partial class BeeControl : UserControl
    {
        public readonly Storyboard FallingStoryboard;

        public BeeControl()
        {
            this.InitializeComponent();
            StartFlapping(TimeSpan.FromMilliseconds(30));
        }

        public BeeControl(double X, double fromY, double toY, EventHandler completed)
            : this()
        {
            FallingStoryboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();

            Storyboard.SetTarget(animation, this);
            Canvas.SetLeft(this, X);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Top)"));
            animation.From = fromY;
            animation.To = toY;
            animation.Duration = TimeSpan.FromSeconds(1);

            if (completed != null) FallingStoryboard.Completed += completed;

            FallingStoryboard.Children.Add(animation);
            FallingStoryboard.Begin();
        }

        public void StartFlapping(TimeSpan interval)
        {
            List<string> imageNames = new List<string>() {
            "Bee animation 1.png", "Bee animation 2.png", "Bee animation 3.png", "Bee animation 4.png"
        };

            Storyboard storyboard = new Storyboard();
            ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();
            Storyboard.SetTarget(animation, image);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Source"));

            TimeSpan currentInteval = TimeSpan.FromMilliseconds(0);
            foreach (string imageName in imageNames)
            {
                ObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame();
                keyFrame.Value = CreateImageFromAssets(imageName);
                keyFrame.KeyTime = currentInteval;
                animation.KeyFrames.Add(keyFrame);
                currentInteval = currentInteval.Add(interval);
            }

            storyboard.RepeatBehavior = RepeatBehavior.Forever;
            storyboard.AutoReverse = true;
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            return new BitmapImage(new Uri("/Assets/" + imageFilename, UriKind.RelativeOrAbsolute));
        }
    }
}
