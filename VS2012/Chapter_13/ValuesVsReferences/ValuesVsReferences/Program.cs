using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuesVsReferences
{
    class Program
    {
        static void Main(string[] args)
        {
            int howMany = 25;
            bool Scary = true;
            List<double> temperatures = new List<double>();
            Exception ex = new Exception("Does not compute");

            int fifteenMore = howMany;
            fifteenMore += 15;
            Console.WriteLine("howMany has {0}, fifteenMore has {1}",
                              howMany, fifteenMore);

            temperatures.Add(56.5D);
            temperatures.Add(27.4D);
            List<double> differentList = temperatures;
            differentList.Add(62.9D);

            Console.WriteLine("temperatures has {0}, differentlist has {1}",
            temperatures.Count(), differentList.Count());
        }
    }
}
