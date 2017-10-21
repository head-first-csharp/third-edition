using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNight.Model
{
    using System.Windows;
    class Star
    {
        public Point Location
        {
            get;
            set;
        }

        public Star(Point location)
        {
            Location = location;
        }
    }
}
