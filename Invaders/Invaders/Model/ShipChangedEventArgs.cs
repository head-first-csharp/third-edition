using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders.Model
{
    using Windows.Foundation;
    class ShipChangedEventArgs : EventArgs
    {
        public Ship ShipUpdated { get; private set; }
        public bool Killed { get; private set; }

        public ShipChangedEventArgs(Ship shipUpdated, bool killed)
        {
            ShipUpdated = shipUpdated;
            Killed = killed;
        }
    }
}
