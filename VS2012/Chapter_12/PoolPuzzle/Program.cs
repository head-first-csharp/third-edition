using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolPuzzle
{
    class Program
    {
        public static void Main()
        {
            Kangaroo joey = new Kangaroo();
            int koala = joey.Wombat(joey.Wombat(joey.Wombat(1)));
            try
            {
                Console.WriteLine((15 / koala) + " eggs per pound");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("G’Day Mate!");
            }
        }

    }
}
