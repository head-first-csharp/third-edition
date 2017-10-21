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

namespace GuySerializer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GuyManager guyManager;

        public MainWindow()
        {
            InitializeComponent();

            guyManager = FindResource("guyManager") as GuyManager;
        }

        private void WriteJoe_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Joe);
        }
        private void WriteBob_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Bob);
        }
        private void WriteEd_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Ed);
        }
        private void ReadNewGuy_Click(object sender, RoutedEventArgs e)
        {
            guyManager.ReadGuy();
        }
    }
}
