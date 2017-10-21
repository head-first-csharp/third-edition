using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetsCreateSomeInstances
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Clown oneClown = new Clown();
            oneClown.Name = "Boffo";
            oneClown.Height = 14;
            oneClown.TalkAboutYourself();

            Clown anotherClown = new Clown();
            anotherClown.Name = "Biff";
            anotherClown.Height = 16;
            anotherClown.TalkAboutYourself();

            Clown clown3 = new Clown();
            clown3.Name = anotherClown.Name;
            clown3.Height = oneClown.Height - 3;
            clown3.TalkAboutYourself();

            anotherClown.Height *= 2;
            anotherClown.TalkAboutYourself();
        }
    }
}
