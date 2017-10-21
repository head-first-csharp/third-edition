using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover9
{
    class Program
    {
        delegate void MyIntAndString(int i, string s);
        delegate int CombineTwoInts(int x, int y);

        static void Main(string[] args)
        {
            /*
             * In Chapter 14, you saw how the var keyword let the IDE determine the
             * type of an object at compile time.  
             * 
             * You can also create objects with anonymous types using var and new.
             * 
             * You can learn more about anonymous types here:
             * http://msdn.microsoft.com/en-us/library/bb397696.aspx
             */

            // Create an anonymous type that looks a lot like a guy:
            var anonymousGuy = new { Name = "Bob", Age = 43, Cash = 137 };

            // When you type this in, the IDE’s IntelliSense automatically picks up
            // the members -- Name, Age and Cash show up in the IntelliSense window.
            Console.WriteLine("{0} is {1} years old and has {2} bucks",
                anonymousGuy.Name, anonymousGuy.Age, anonymousGuy.Cash);
            // Output: Bob is 43 years old and has 137 bucks

            // An instance of an anonymous type has a sensible ToString() method.
            Console.WriteLine(anonymousGuy.ToString());
            // Output: { Name = Bob, Age = 43, Cash = 137 }

            /*
             * In Chapter 15, you learned about how you can use a delegate to reference 
             * a method. In all of the examples of delegates that you've seen so far,
             * you assigned an existing method to a delegate. 
             * 
             * Anonymous methods are methods that you declare in a statement -- you
             * declare them using curly brackets { }, just like with anonymous types.
             * 
             * You can learn more about anonymous methods here:
             * http://msdn.microsoft.com/en-us/library/0yw3tz5k.aspx
             */

            // Here’s an anonymous method that writes an int and a string to the console.
            // Its declaration matches our MyIntAndString delegate (defined above), so
            // we can assign it to a variable of type MyIntAndString.
            MyIntAndString printThem = delegate(int i, string s)
            { Console.WriteLine("{0} - {1}", i, s); };
            printThem(123, "four five six");
            // Output: 123 - four five six

            // Here’s another anonymous method with the same signature (int, string). 
            // This one checks if the string contains the int.
            MyIntAndString contains = delegate(int i, string s)
            { Console.WriteLine(s.Contains(i.ToString())); };
            contains(123, "four five six");
            // Output: False

            contains(123, "four 123 five six");
            // Output: True

            // You can dynamically invoke a method using Delegate.DynamicInvoke(),
            // passing the parameters to the method as an array of objects.
            Delegate d = contains;
            d.DynamicInvoke(new object[] { 123, "four 123 five six" });
            // Output: True

            /*
             * A lambda expression is a special kind of anonymous method that uses 
             * the => operator. It's called the lambda operator, but when you're
             * talking about lambda expressions you usually say "goes to" when 
             * you read it. Here's a simple lambda expression:
             * 
             *    (a, b) => { return a + b; }
             * 
             * You could read that as "a and b goes to a plus b" -- it's an anonymous
             * method for adding two values. You can think of lambda expressions as
             * anonymous methods that take parameters and can return values.
             * 
             * You can learn more about lambda expressions here:
             * http://msdn.microsoft.com/en-us/library/bb397687.aspx
             */

            // Here’s that lambda expression for adding two numbers. Its signature
            // matches our CombineTwoInts delegate, so we can assign it to a delegate
            // variable of type CombineTwoInts. Notice how CombineTwoInts’s return
            // type is int -- that means the lambda expression needs to return an int.
            CombineTwoInts adder = (a, b) => { return a + b; };
            Console.WriteLine(adder(3, 5));
            // Output: 8

            // Here's another lambda expression -- this one multiplies two numbers.
            CombineTwoInts multiplier = (int a, int b) => { return a * b; };
            Console.WriteLine(multiplier(3, 5));
            // Output: 15

            // You can do some seriously powerful stuff when you combine lambda 
            // expressions with LINQ. Here’s a really simple example:
            var greaterThan3 = new List<int> { 1, 2, 3, 4, 5, 6 }.Where(x => x > 3);
            foreach (int i in greaterThan3) Console.Write("{0} ", i);
            // Output: 4 5 6 

            Console.ReadKey();
        }
    }
}
