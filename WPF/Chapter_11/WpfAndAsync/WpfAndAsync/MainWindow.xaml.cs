using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAndAsync
{
    using System.Threading;
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(.1);
        }

        int i = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            progress.Text = (i++).ToString();
        }

        private async void countButton_Click(object sender, RoutedEventArgs e)
        {
            countButton.IsEnabled = false;
            timer.Start();
            if (useAwaitAsync.IsChecked == true)
                await LongTaskAsync();
            else
                LongTask();
            countButton.IsEnabled = true;
        }

        private void LongTask()
        {
            Thread.Sleep(5000);
            timer.Stop();
        }

        private async Task LongTaskAsync()
        {
            await Task.Delay(5000);
            timer.Stop();
        }
    }

}
