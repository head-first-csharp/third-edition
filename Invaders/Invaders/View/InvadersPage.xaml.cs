using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Invaders.View
{
    using Windows.UI.Core;
    using Windows.UI.ApplicationSettings;
    using Windows.UI.Popups;

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class InvadersPage : Invaders.Common.LayoutAwarePage
    {
        public InvadersPage()
        {
            this.InitializeComponent();

            SettingsPane.GetForCurrentView().CommandsRequested += InvadersPage_CommandsRequested;
        }

        void InvadersPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            UICommandInvokedHandler invokedHandler =
                                new UICommandInvokedHandler(AboutInvokedHandler);
            SettingsCommand aboutCommand = new SettingsCommand("About", "About Invaders",
                                                      invokedHandler);
            args.Request.ApplicationCommands.Add(aboutCommand);
        }

        private void AboutInvokedHandler(IUICommand command)
        {
            viewModel.Paused = true;
            aboutPopup.IsOpen = true;
        }

        private void CloseAboutPopup(object sender, RoutedEventArgs e)
        {
            aboutPopup.IsOpen = false;
            viewModel.Paused = false;
        }

        private void LearnButton(object sender, RoutedEventArgs e)
        {
            learnMorePopup.IsOpen = true;
        }

        private void CloseLearnMorePopup(object sender, RoutedEventArgs e)
        {
            learnMorePopup.IsOpen = false;
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            aboutPopup.IsOpen = false;
            learnMorePopup.IsOpen = false;
            viewModel.StartGame();
            firstTapOfGame = true;
        }


        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            viewModel.KeyDown(e.VirtualKey);
        }

        private void KeyUpHandler(object sender, KeyEventArgs e)
        {
            viewModel.KeyUp(e.VirtualKey);
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown += KeyDownHandler;
            Window.Current.CoreWindow.KeyUp += KeyUpHandler;
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= KeyDownHandler;
            Window.Current.CoreWindow.KeyUp -= KeyUpHandler;
            base.OnNavigatedFrom(e);
        }


        private void pageRoot_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e.Delta.Translation.X < -1)
                viewModel.LeftGestureStarted();
            else if (e.Delta.Translation.X > 1)
                viewModel.RightGestureStarted();
        }

        private void pageRoot_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            viewModel.LeftGestureCompleted();
            viewModel.RightGestureCompleted();
        }

        bool firstTapOfGame = false;
        private void pageRoot_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!firstTapOfGame)
                viewModel.Tapped();

            firstTapOfGame = false;
        }

        private void playArea_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePlayAreaSize(playArea.RenderSize);
        }

        private void pageRoot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePlayAreaSize(new Size(e.NewSize.Width, e.NewSize.Height - 160));
        }

        private void UpdatePlayAreaSize(Size newPlayAreaSize)
        {
            double targetWidth;
            double targetHeight;
            if (newPlayAreaSize.Width > newPlayAreaSize.Height)
            {
                targetWidth = newPlayAreaSize.Height * 4 / 3;
                targetHeight = newPlayAreaSize.Height;
                double leftRightMargin = (newPlayAreaSize.Width - targetWidth) / 2;
                playArea.Margin = new Thickness(leftRightMargin, 0, leftRightMargin, 0);
            }
            else
            {
                targetHeight = newPlayAreaSize.Width * 3 / 4;
                targetWidth = newPlayAreaSize.Width;
                double topBottomMargin = (newPlayAreaSize.Height - targetHeight) / 2;
                playArea.Margin = new Thickness(0, topBottomMargin, 0, topBottomMargin);
            }
            playArea.Width = targetWidth;
            playArea.Height = targetHeight;
            viewModel.PlayAreaSize = new Size(targetWidth, targetHeight);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}
