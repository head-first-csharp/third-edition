using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionMagnets
{
    class Program
    {
        public static void Main()
        {
            Console.Write("when it ");
            ExTestDrive.Zero("yes");
            Console.Write(" it ");
            ExTestDrive.Zero("no");
            Console.WriteLine(".");
        }
    }
}
