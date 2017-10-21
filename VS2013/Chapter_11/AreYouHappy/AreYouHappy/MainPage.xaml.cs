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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AreYouHappy
{
    using Windows.UI.Popups;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        DispatcherTimer timer = new DispatcherTimer();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Start();
            CheckHappiness();
        }
        int i = 0;
        void timer_Tick(object sender, object e)
        {
            ticker.Text = "Tick #" + i++;
        }
        private async void CheckHappiness()
        {
            MessageDialog dialog = new MessageDialog("Are you happy?");
            dialog.Commands.Add(new UICommand("Happy as a clam!"));
            dialog.Commands.Add(new UICommand("Sad as a donkey."));
            dialog.DefaultCommandIndex = 1;
            UICommand result = await dialog.ShowAsync() as UICommand;
            if (result != null && result.Label == "Happy as a clam!")
                response.Text = "The user is happy";
            else
                response.Text = "The user is sad";
            timer.Stop();
        }

    }
}
