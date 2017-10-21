using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNight.Model
{
    using System.Windows;
    class BeeMovedEventArgs : EventArgs
    {
        public Bee BeeThatMoved { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }

        public BeeMovedEventArgs(Bee beeThatMoved, double x, double y)
        {
            BeeThatMoved = beeThatMoved;
            X = x;
            Y = y;
        }
    }
}
