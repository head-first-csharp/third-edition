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

namespace JimmysComics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ComicQueryManager comicQueryManager;

        public MainWindow()
        {
            InitializeComponent();

            comicQueryManager = FindResource("comicQueryManager") as ComicQueryManager;
            comicQueryManager.UpdateQueryResults(comicQueryManager.AvailableQueries[0]);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count >= 1 && e.AddedItems[0] is ComicQuery)
            {
                comicQueryManager.CurrentQueryResults.Clear();
                comicQueryManager.UpdateQueryResults(e.AddedItems[0] as ComicQuery);
            }
        }
    }
}
