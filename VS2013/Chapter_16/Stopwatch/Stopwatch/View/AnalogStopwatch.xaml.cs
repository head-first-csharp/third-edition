using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Stopwatch.View
{
    using Windows.UI;
    using Windows.UI.Xaml.Shapes;
    using Windows.UI.Xaml.Media;
    public sealed partial class AnalogStopwatch : UserControl
    {
        public AnalogStopwatch()
        {
            this.InitializeComponent();
            AddMarkings();
        }

        private void AddMarkings()
        {
            for (int i = 0; i < 360; i += 3)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = (i % 30 == 0) ? 3 : 1;
                rectangle.Height = 15;
                rectangle.Fill = new SolidColorBrush(Colors.Black);
                rectangle.RenderTransformOrigin = new Point(0.5, 0.5);

                TransformGroup transforms = new TransformGroup();
                transforms.Children.Add(new TranslateTransform() { Y = -140 });
                transforms.Children.Add(new RotateTransform() { Angle = i });
                rectangle.RenderTransform = transforms;
                baseGrid.Children.Add(rectangle);
            }
        }
        
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Start();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Stop();
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Reset();
        }
        private void LapButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Lap();
        }
    }
}
