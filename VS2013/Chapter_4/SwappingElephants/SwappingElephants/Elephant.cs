using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwappingElephants
{
    using System.Windows.Forms;

    class Elephant
    {
        public int EarSize;
        public string Name;
        public void WhoAmI()
        {
            MessageBox.Show("My ears are " + EarSize + " inches tall.",
               Name + " says…");
        }
    }
}
