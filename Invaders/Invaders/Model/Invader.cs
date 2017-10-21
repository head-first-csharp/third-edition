using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders.Model
{
    using Windows.Foundation;

    class Invader : Ship
    {
        public static readonly Size InvaderSize = new Size(15, 15);
        public const int HorizontalInterval = 5;
        public const int VerticalInterval = 15;

        public InvaderType InvaderType { get; private set; }

        public int Score { get; private set; }

        public Invader(InvaderType invaderType, Point location, int score)
            : base(location, Invader.InvaderSize)
        {
            this.InvaderType = invaderType;
            this.Score = score;
        }

        public override void Move(Direction invaderDirection)
        {
            switch (invaderDirection)
            {
                case Direction.Right:
                    Location = new Point(Location.X + HorizontalInterval, Location.Y);
                    break;
                case Direction.Left:
                    Location = new Point(Location.X - HorizontalInterval, Location.Y);
                    break;
                default:
                    Location = new Point(Location.X, Location.Y + VerticalInterval);
                    break;
            }
        }
    }
}
