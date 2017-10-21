using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders.Model
{
    using Windows.Foundation;

    class Player : Ship
    {
        public static readonly Size PlayerSize = new Size(25, 15);
        const double PixelsToMove = 10;

        public Player()
            : base(new Point(PlayerSize.Width, InvadersModel.PlayAreaSize.Height - InvadersModel.PlayAreaSize.Height * 3), Player.PlayerSize) 
        {
            Location = new Point(Location.X, InvadersModel.PlayAreaSize.Height - PlayerSize.Height * 3);
        }

        public override void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (Location.X > PlayerSize.Width)
                        Location = new Point(Location.X - PixelsToMove, Location.Y);
                    break;
                default:
                    if (Location.X < InvadersModel.PlayAreaSize.Width - PlayerSize.Width * 2)
                        Location = new Point(Location.X + PixelsToMove, Location.Y);
                    break;
            }
        }
    }
}
