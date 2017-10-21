using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders.Model
{
    using Windows.Foundation;
    class StarChangedEventArgs : EventArgs
    {
        public Point Point { get; private set; }
        public bool Disappeared { get; private set; }

        public StarChangedEventArgs(Point point, bool disappeared)
        {
            Point = point;
            Disappeared = disappeared;
        }
    }
}
