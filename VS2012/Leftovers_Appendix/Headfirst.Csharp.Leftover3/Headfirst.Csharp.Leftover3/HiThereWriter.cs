using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headfirst.Csharp.Leftover3
{
    using System.Windows.Forms;

    public static class HiThereWriter
    {
        public static void HiThere(string name)
        {
            MessageBox.Show("Hi there! My name is " + name);
        }
    }
}
