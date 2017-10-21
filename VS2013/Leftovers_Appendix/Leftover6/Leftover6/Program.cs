using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover6
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy joe1 = new Guy("Joe", 37, 100);
            Guy joe2 = joe1;
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2)); // True
            Console.WriteLine(joe1.Equals(joe2));                  // True
            Console.WriteLine(Object.ReferenceEquals(null, null)); // True

            joe2 = new Guy("Joe", 37, 100);
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2)); // False
            Console.WriteLine(joe1.Equals(joe2));                  // False

            joe1 = new EquatableGuy("Joe", 37, 100);
            joe2 = new EquatableGuy("Joe", 37, 100);
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2)); // False
            Console.WriteLine(joe1.Equals(joe2));                  // True

            joe1.GiveCash(50);
            Console.WriteLine(joe1.Equals(joe2));                  // False
            joe2.GiveCash(50);
            Console.WriteLine(joe1.Equals(joe2));                  // True

            List<Guy> guys = new List<Guy>() {
                new Guy("Bob", 42, 125),
                new EquatableGuy(joe1.Name, joe1.Age, joe1.Cash),
                new Guy("Ed", 39, 95)
            };
            Console.WriteLine(guys.Contains(joe1));                // True
            Console.WriteLine(joe1 == joe2);                       // False


            joe1 = new EquatableGuyWithOverload(joe1.Name, joe1.Age, joe1.Cash);
            joe2 = new EquatableGuyWithOverload(joe1.Name, joe1.Age, joe1.Cash);
            Console.WriteLine(joe1 == joe2); // False
            Console.WriteLine(joe1 != joe2); // True
            Console.WriteLine((EquatableGuyWithOverload)joe1 == (EquatableGuyWithOverload)joe2); // True
            Console.WriteLine((EquatableGuyWithOverload)joe1 != (EquatableGuyWithOverload)joe2); // False
            joe2.ReceiveCash(25);
            Console.WriteLine((EquatableGuyWithOverload)joe1 == (EquatableGuyWithOverload)joe2); // False
            Console.WriteLine((EquatableGuyWithOverload)joe1 != (EquatableGuyWithOverload)joe2); // True

            Console.ReadKey();

        }
    }
}
