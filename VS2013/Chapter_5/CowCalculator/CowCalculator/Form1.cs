using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CowCalculator
{
    public partial class Form1 : Form
    {
        Farmer farmer;

        public Form1()
        {
            InitializeComponent();
            farmer = new Farmer(15, 30);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            farmer.NumberOfCows = (int)numericUpDown1.Value;
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("I need {0} bags of feed for {1} cows",
                farmer.BagsOfFeed, farmer.NumberOfCows);
        }
    }
}
