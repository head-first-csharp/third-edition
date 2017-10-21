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

namespace UseTheDebugger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * Double-clicking on the Button in the designer caused it to
         * create the empty Button_Click() method.
         */

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number = 15;           // There's a breakpoint on this line
            number = number + 10;
            number = 36 * 15;
            number = 12 - (42 / 7);
            number += 10;
            number *= 3;
            number = 71 / 3;

            int count = 0;
            count++;
            count--;

            string result = "hello";
            result += " again " + result;
            output.Text = result;
            result = "the value is: " + count;
            result = "";

            bool yesNo = false;
            bool anotherBool = true;
            yesNo = !anotherBool;
        }
    }
}
