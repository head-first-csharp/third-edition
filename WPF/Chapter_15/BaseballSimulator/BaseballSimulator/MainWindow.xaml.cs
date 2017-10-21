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

namespace BaseballSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseballSimulator baseballSimulator;

        public MainWindow()
        {
            InitializeComponent();

            baseballSimulator = FindResource("baseballSimulator") as BaseballSimulator;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            baseballSimulator.PlayBall();
        }
    }
}
