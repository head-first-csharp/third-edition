using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeVersusFinalizer
{
    using System.Windows.Forms;

    class Clone : IDisposable
    {
        public int Id { get; private set; }

        public Clone(int Id)
        {
            this.Id = Id;
        }

        public void Dispose()
        {
            MessageBox.Show("I’ve been disposed!",
                       "Clone #" + Id + " says...");
        }

        ~Clone()
        {
            MessageBox.Show("Aaargh! You got me!",
                       "Clone #" + Id + " says...");
        }
    }
}
