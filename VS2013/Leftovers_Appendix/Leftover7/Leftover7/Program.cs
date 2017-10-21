using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SportCollection contents:");
            SportCollection sportCollection = new SportCollection();
            foreach (Sport sport in sportCollection)
                Console.WriteLine(sport.ToString());


            IEnumerable<string> names = NameEnumerator(); // Put a breakpoint here
            foreach (string name in names)
                Console.WriteLine(name);

            Console.WriteLine(sportCollection[3]);

            GuyCollection guyCollection = new GuyCollection();
            Console.WriteLine("Adding two guys and modifying one guy");
            guyCollection["Bob"] = guyCollection["Joe"] + 3;
            guyCollection["Bill"] = 57;
            guyCollection["Harry"] = 31;
            foreach (Guy guy in guyCollection)
                Console.WriteLine(guy.ToString());

            Console.ReadKey();
        }

        static IEnumerable<string> NameEnumerator()
        {
            yield return "Bob"; // The method exits after this statement ...
            yield return "Harry"; // ... and resumes here the next time through
            yield return "Joe";
            yield return "Frank";
        }
    }
}
