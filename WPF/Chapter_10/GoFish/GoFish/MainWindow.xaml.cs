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

namespace GoFish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = this.FindResource("game") as Game;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            game.StartGame();
        }
        private void askForACard_Click(object sender, RoutedEventArgs e)
        {
            if (cards.SelectedIndex >= 0)
                game.PlayOneRound(cards.SelectedIndex);
        }
        private void cards_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (cards.SelectedIndex >= 0)
                game.PlayOneRound(cards.SelectedIndex);
        }
    }
}
