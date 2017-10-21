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

namespace JimmysComics
{
    using Windows.UI.ApplicationSettings;
    using Windows.UI.Popups;

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : JimmysComics.Common.LayoutAwarePage
    {
        static bool aboutCommandAdded = false;
        public MainPage()
        {
            this.InitializeComponent();
            if (!aboutCommandAdded)
            {
                SettingsPane.GetForCurrentView().CommandsRequested += MainPage_CommandsRequested;
                aboutCommandAdded = true;
            }
        }

        void MainPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            UICommandInvokedHandler invokedHandler =
                                        new UICommandInvokedHandler(AboutInvokedHandler);
            SettingsCommand aboutCommand = new SettingsCommand("About", "About Jimmy's Comics",
                                                      invokedHandler);
            args.Request.ApplicationCommands.Add(aboutCommand);
        }

        async void AboutInvokedHandler(IUICommand command)
        {
            await new MessageDialog("An app to help Jimmy manage his comic collection",
                            "Jimmy's Comics").ShowAsync();
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

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ComicQuery query = e.ClickedItem as ComicQuery;
            if (query != null)
            {
                SuspensionManager.CurrentQuery = query.Title;

                if (query.Title == "All comics in the collection")
                    this.Frame.Navigate(typeof(QueryDetailZoom), query);
                else
                    this.Frame.Navigate(typeof(QueryDetail), query);
            }
        }
    }
}
