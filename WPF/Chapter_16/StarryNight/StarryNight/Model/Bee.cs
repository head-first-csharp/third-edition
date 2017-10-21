using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNight.Model
{
    using System.Windows;
    class Bee
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public Rect Position { get { return new Rect(Location, Size); } }
        public double Width { get { return Position.Width; } }
        public double Height { get { return Position.Height; } }

        public Bee(Point location, Size size)
        {
            Location = location;
            Size = size;
        }
    }
}
