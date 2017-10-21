using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNight.View
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Shapes;

    static class BeeStarHelper
    {
        public static AnimatedImage BeeFactory(double width, double height, TimeSpan flapInterval)
        {
            List<string> imageNames = new List<string>();
            imageNames.Add("Bee animation 1.png");
            imageNames.Add("Bee animation 2.png");
            imageNames.Add("Bee animation 3.png");
            imageNames.Add("Bee animation 4.png");

            AnimatedImage bee = new AnimatedImage(imageNames, flapInterval);
            bee.Width = width;
            bee.Height = height;
            return bee;
        }

        public static void SetCanvasLocation(UIElement control, double x, double y)
        {
            Canvas.SetLeft(control, x);
            Canvas.SetTop(control, y);
        }

        public static void MoveElementOnCanvas(UIElement uiElement, double toX, double toY)
        {
            double fromX = Canvas.GetLeft(uiElement);
            double fromY = Canvas.GetTop(uiElement);

            Storyboard storyboard = new Storyboard();
            DoubleAnimation animationX = CreateDoubleAnimation(uiElement,
                                                fromX, toX, "(Canvas.Left)");
            DoubleAnimation animationY = CreateDoubleAnimation(uiElement,
                                                fromY, toY, "(Canvas.Top)");
            storyboard.Children.Add(animationX);
            storyboard.Children.Add(animationY);
            storyboard.Begin();
        }

        public static DoubleAnimation CreateDoubleAnimation(UIElement uiElement,
                                             double from, double to, string propertyToAnimate)
        {
            DoubleAnimation animation = new DoubleAnimation();
            Storyboard.SetTarget(animation, uiElement);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(3);
            return animation;
        }

        public static void SendToBack(StarControl newStar)
        {
            Canvas.SetZIndex(newStar, -1000);
        }
    }
}
