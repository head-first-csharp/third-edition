using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNight.Model
{
    using System.Windows;
    class StarChangedEventArgs : EventArgs
    {
        public Star StarThatChanged { get; private set; }
        public bool Removed { get; private set; }

        public StarChangedEventArgs(Star starThatChanged, bool removed)
        {
            StarThatChanged = starThatChanged;
            Removed = removed;
        }
    }
}
