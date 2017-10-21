using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover5
{
    class Program
    {
        class NestedClass
        {
            public class DoubleNestedClass
            {
                // Nested class contents ...
            }
        }

        static void Main(string[] args)
        {
            Type guyType = typeof(Guy);
            Console.WriteLine("{0} extends {1}",
                guyType.FullName,
                guyType.BaseType.FullName);
            // output: TypeExamples.Guy extends System.Object

            Type nestedClassType = typeof(NestedClass.DoubleNestedClass);
            Console.WriteLine(nestedClassType.FullName);
            // output: TypeExamples.Program+NestedClass+DoubleNestedClass

            List<Guy> guyList = new List<Guy>();
            Console.WriteLine(guyList.GetType().Name);
            // output: List`1

            Dictionary<string, Guy> guyDictionary = new Dictionary<string, Guy>();
            Console.WriteLine(guyDictionary.GetType().Name);
            // output: Dictionary`2

            Type t = typeof(Program);
            Console.WriteLine(t.FullName);
            // output: TypeExamples.Program

            Type intType = typeof(int);
            Type int32Type = typeof(Int32);
            Console.WriteLine("{0} - {1}", intType.FullName, int32Type.FullName);
            // System.Int32 - System.Int32

            Console.WriteLine("{0} {1}", float.MinValue, float.MaxValue);
            // output:-3.402823E+38 3.402823E+38

            Console.WriteLine("{0} {1}", int.MinValue, int.MaxValue);
            // output:-2147483648 2147483647

            Console.WriteLine("{0} {1}", DateTime.MinValue, DateTime.MaxValue);
            // output: 1/1/0001 12:00:00 AM 12/31/9999 11:59:59 PM

            Console.WriteLine(12345.GetType().FullName);
            // output: System.Int32

            Console.ReadKey();
        }
    }
}
