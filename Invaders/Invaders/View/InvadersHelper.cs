using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders.View
{
    using Model;
    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Shapes;

    static class InvadersHelper
    {
        private static readonly Random _random = new Random();

        public static IEnumerable<string> CreateImageList(InvaderType shipType)
        {
            string filename;
            switch (shipType)
            {
                case InvaderType.Bug:
                    filename = "bug";
                    break;
                case InvaderType.Spaceship:
                    filename = "spaceship";
                    break;
                case InvaderType.Star:
                    filename = "star";
                    break;
                case InvaderType.Satellite:
                default:
                    filename = "satellite";
                    break;
            }
            List<string> imageList = new List<string>();
            for (int i = 1; i <= 4; i++)
                imageList.Add(filename + i + ".png");
            return imageList;
        }

        internal static FrameworkElement InvaderControlFactory(Invader invader, double scale)
        {
            IEnumerable<string> imageNames = CreateImageList(invader.InvaderType);
            AnimatedImage invaderControl = new AnimatedImage(imageNames, TimeSpan.FromSeconds(.75));
            invaderControl.Width = invader.Size.Width * scale;
            invaderControl.Height = invader.Size.Height * scale;
            SetCanvasLocation(invaderControl, invader.Location.X * scale, invader.Location.Y * scale);
            
            return invaderControl;
        }

        internal static FrameworkElement ShotControlFactory(Shot shot, double scale)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Colors.Yellow);
            rectangle.Width = Shot.ShotSize.Width * scale;
            rectangle.Height = Shot.ShotSize.Height * scale;
            SetCanvasLocation(rectangle, shot.Location.X * scale, shot.Location.Y * scale);
            return rectangle;
        }

        internal static FrameworkElement StarControlFactory(Point point, double scale)
        {
            FrameworkElement star;
            switch (_random.Next(3))
            {
                case 0:
                    star = new Rectangle();
                    ((Rectangle)star).Fill = new SolidColorBrush(RandomStarColor());
                    star.Width = 2;
                    star.Height = 2;
                    break;
                case 1 :
                    star = new Ellipse();
                    ((Ellipse)star).Fill = new SolidColorBrush(RandomStarColor());
                    star.Width = 2;
                    star.Height = 2;
                    break;
                default:
                    star = new StarControl();
                    ((StarControl)star).SetFill(new SolidColorBrush(RandomStarColor()));
                    break;
            }
            SetCanvasLocation(star, point.X * scale, point.Y * scale);
            Canvas.SetZIndex(star, -1000);
            return star;
        }

        public static FrameworkElement ScanLineFactory(int y, int width, double scale)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = width * scale;
            rectangle.Height = 2;
            rectangle.Opacity = .1;
            rectangle.Fill = new SolidColorBrush(Colors.White);
            SetCanvasLocation(rectangle, 0, y * scale);
            return rectangle;
        }

        private static Color RandomStarColor()
        {
            switch (_random.Next(6))
            {
                case 0:
                    return Colors.White;
                case 1:
                    return Colors.LightBlue;
                case 2:
                    return Colors.MediumPurple;
                case 3:
                    return Colors.PaleVioletRed;
                case 4:
                    return Colors.Yellow;
                default:
                    return Colors.LightSlateGray;
            }
        }

        internal static FrameworkElement PlayerControlFactory(Player player, double scale)
        {
            AnimatedImage playerControl = new AnimatedImage(new List<string>() { "player.png", "player.png" }, TimeSpan.FromSeconds(1));
            playerControl.Width = player.Size.Width * scale;
            playerControl.Height = player.Size.Height * scale;
            SetCanvasLocation(playerControl, player.Location.X * scale, player.Location.Y * scale);
            return playerControl;
        }

        public static void SetCanvasLocation(FrameworkElement control, double x, double y)
        {
            Canvas.SetLeft(control, x);
            Canvas.SetTop(control, y);
        }

        public static void MoveElementOnCanvas(FrameworkElement FrameworkElement, double toX, double toY)
        {
            double fromX = Canvas.GetLeft(FrameworkElement);
            double fromY = Canvas.GetTop(FrameworkElement);

            Storyboard storyboard = new Storyboard();
            DoubleAnimation animationX = CreateDoubleAnimation(FrameworkElement,
                                                fromX, toX, "(Canvas.Left)");
            DoubleAnimation animationY = CreateDoubleAnimation(FrameworkElement,
                                                fromY, toY, "(Canvas.Top)");
            storyboard.Children.Add(animationX);
            storyboard.Children.Add(animationY);
            storyboard.Begin();
        }

        public static DoubleAnimation CreateDoubleAnimation(FrameworkElement frameworkElement,
                                     double from, double to, string propertyToAnimate)
        {
            return CreateDoubleAnimation(frameworkElement, from, to, propertyToAnimate, TimeSpan.FromMilliseconds(25));
        }

        public static DoubleAnimation CreateDoubleAnimation(FrameworkElement frameworkElement,
                                             double from, double to, string propertyToAnimate, TimeSpan timeSpan)
        {
            DoubleAnimation animation = new DoubleAnimation();
            Storyboard.SetTarget(animation, frameworkElement);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);
            animation.From = from;
            animation.To = to;
            animation.Duration = timeSpan;
            return animation;
        }

        public static void ResizeElement(FrameworkElement control, double width, double height)
        {
            if (control.Width != width)
                control.Width = width;
            if (control.Height != height)
                control.Height = height;
        }

        public static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/" + imageFilename));
        }
    }
}
