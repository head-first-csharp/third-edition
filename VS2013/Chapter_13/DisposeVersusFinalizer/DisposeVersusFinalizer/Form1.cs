using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisposeVersusFinalizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clone1_Click(object sender, EventArgs e)
        {
            using (Clone clone1 = new Clone(1))
            {
                // Do nothing!
            }
        }


        private void clone2_Click(object sender, EventArgs e)
        {
            Clone clone2 = new Clone(2);
            clone2 = null;
        }

        private void gc_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

    }
}
