using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover2
{
    class Program
    {
        static void Main(string[] args)
        {
            // We'll use these Guy and Random instances throughout this example.
            Guy bob = new Guy("Bob", 43, 100);
            Guy joe = new Guy("Joe", 41, 100);
            Random random = new Random();


            /*
             * Here are two useful keywords that you can use with loops. The "continue" keyword
             * tells the loop to jump to the next iteration of a loop, and the "break" keyword
             * tells the loop to end immediately.
             * 
             * The break, continue, throw, and return statements are called "jump statements" 
             * because they cause your program to jump to another place in the code when they're 
             * executed. (You learned about break with switch/case statements in Chapter 8, and
             * the throw statement in Chapter 10.) There's one more jump statement, goto, which 
             * jumps to a label. (You'll recognize these labels as having very similar syntax 
             * to what you use in a case statement.)
             *  
             * You could easily write this next loop without continue and break. That's a good
             * example of how C# lets you do the same thing many different ways. That's why you
             * don't need break, continue, or any of these other keywords or operators to write
             * any of the programs in this book.
             * 
             * The break statement is also used with "case", which you can see in Chapter 8.
             */

            while (true)
            {
                int amountToGive = random.Next(20);

                // The continue keyword jumps to the next iteration of a loop
                // Use the continue keyword to only give Joe amounts over 10 bucks
                if (amountToGive < 10)
                    continue;

                // The break keyword terminates a loop early
                if (joe.ReceiveCash(bob.GiveCash(amountToGive)) == 0)
                    break;

                Console.WriteLine("Bob gave Joe {0} bucks, Joe has {1} bucks, Bob has {2} bucks",
                    amountToGive, joe.Cash, bob.Cash);
            }
            Console.WriteLine("Bob's left with {0} bucks", bob.Cash);

            // The ?: conditional operator is an if/then/else collapsed into a single expression
            // [boolean test] ? [statement to execute if true] : [statement to execute if false]
            Console.WriteLine("Bob {0} more cash than Joe",
                bob.Cash > joe.Cash ? "has" : "does not have");

            // The ?? null coalescing operator checks if a value is null, and either returns
            // that value if it's not null, or the value you specify if it is
            // [value to test] ?? [value to return if it's null]
            bob = null;
            Console.WriteLine("Result of ?? is '{0}'", bob ?? joe);


            // Here's a loop that uses goto statements and labels. It's rare to see them, but
            // they can be useful with nested loops. (The break statement only breaks out of 
            // the innermost loop)
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i > 3)
                        goto afterLoop;
                    Console.WriteLine("i = {0}, j = {1}", i, j);
                }
            }
        afterLoop:



            // When you use the = operator to make an assignment, it returns a value that you 
            // can turn around and use in an assignment or an if statement
            int a;
            int b = (a = 3 * 5);
            Console.WriteLine("a = {0}; b = {1};", a, b);

            // When you put the ++ operator before a variable, it increments the variable 
            // first, and then executes the rest of the statement.
            a = ++b * 10;
            Console.WriteLine("a = {0}; b = {1};", a, b);

            // Putting it after the variable executes the statement first and then increments
            a = b++ * 10;
            Console.WriteLine("a = {0}; b = {1};", a, b);


            /*
             * When you use && and || to do logical tests, they "short-circuit" -- which means
             * that as soon as the test fails, they stop executing. When (A || B) is being
             * evaluated, if A is true then (A || B) will always be true no matter what B is.
             * And when (A && B) is being evaluated, then if A is false then (A && B) will always
             * be false no matter what B is. In both of those cases, B will never get executed
             * because the operator doesn't need its value in order to come up with a return value.
             */

            int x = 0;
            int y = 10;
            int z = 20;

            // y / x will throw a DivideByZeroException because x is 0. But since (y < z) is true, 
            // the || operator knows it will be true without ever having to execute the other 
            // statement, so it short-circuits and never executes (y / x == 4)
            if ((y < z) || (y / x == 4))
                Console.WriteLine("this line printed because || short-circuited");

            // Since (y > z) is false, the && operator knows it will return false without
            // executing the other statement, so it short-circuits and doesn't throw the exception
            if ((y > z) && (y / x == 4))
                Console.WriteLine("this line will never print because && short-circuited");



            /*
             * A lot of us think of 1's and 0's when we think of programming, and manipulating
             * those 1's and 0's is what logic operators are all about. 
             */

            // Use Convert.ToString() and Convert.ToInt32() to convert a number to or from a
            // string of 1's and 0's in its binary form. The second argument specifies that you're 
            // converting to base 2.
            string binaryValue = Convert.ToString(217, 2);
            int intValue = Convert.ToInt32(binaryValue, 2);
            Console.WriteLine("Binary {0} is integer {1}", binaryValue, intValue);

            // The &, |, ^, and ~ operators are logical AND, OR, XOR, and bitwise complement
            int val1 = Convert.ToInt32("100000001", 2);
            int val2 = Convert.ToInt32("001010100", 2);
            int or = val1 | val2;
            int and = val1 & val2;
            int xor = val1 ^ val2;
            int not = ~val1;


            // Print the values -- and use the String.PadLeft() method to add leading 0's
            Console.WriteLine("val1: {0}", Convert.ToString(val1, 2));
            Console.WriteLine("val2: {0}", Convert.ToString(val2, 2).PadLeft(9, '0'));
            Console.WriteLine("  or: {0}", Convert.ToString(or, 2).PadLeft(9, '0'));
            Console.WriteLine(" and: {0}", Convert.ToString(and, 2).PadLeft(9, '0'));
            Console.WriteLine(" xor: {0}", Convert.ToString(xor, 2).PadLeft(9, '0'));
            Console.WriteLine(" not: {0}", Convert.ToString(not, 2).PadLeft(9, '0'));
            // Notice what the ~ operator returned:  11111111111111111111111011111110
            // It's the 32-bit complement of val1: 00000000000000000000000100000001
            // The logical operators are operating on int, which is a 32-bit integer.

            // The << and >> operators shift bits left and right. And you can combine any
            // logical operator with =, so >>= or &= is just like += or *=.
            int bits = Convert.ToInt32("11", 2);
            for (int i = 0; i < 5; i++)
            {
                bits <<= 2;
                Console.WriteLine(Convert.ToString(bits, 2).PadLeft(12, '0'));
            }
            for (int i = 0; i < 5; i++)
            {
                bits >>= 2;
                Console.WriteLine(Convert.ToString(bits, 2).PadLeft(12, '0'));
            }


            // You can instantiate a new object and call a method on it without 
            // using a variable to refer to it. 
            Console.WriteLine(new Guy("Harry", 47, 376).ToString());


            // We've used the + operator for string concatenation throughout the book, and that
            // works just fine. However, a lot of people avoid using + in loops that will have
            // to execute many times over time, because each time + executes it creates an extra
            // object on the heap that will need to be garbage collected later. That's why .NET
            // has a class called StringBuilder, which is great for efficiently creating and 
            // concatenating strings together. Its Append() method adds a string onto the end,
            // AppendFormat() appends a formatted string (using {0} and {1} just like 
            // String.Format() and Console.WriteLine() do), and AppendLine() adds a string 
            // with a line break at the end. To get the final concatenated string, call
            // its ToString() method.
            StringBuilder stringBuilder = new StringBuilder("Hi ");
            stringBuilder.Append("there, ");
            stringBuilder.AppendFormat("{0} year old guy named {1}. ", joe.Age, joe.Name);
            stringBuilder.AppendLine("Nice weather we're having.");
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();


            /*
             * This is a good start, but it's by no means complete. Luckily, Microsoft gives you
             * a reference that has a complete list of all of the C# operators, keywords, and
             * other features of the language. Take a look through it -- and if you're just getting
             * started with C#, don't worry if it seems a little difficult to understand. MSDN
             * is a great source of information, but it's meant to be a reference, not a learning
             * or teaching guide.
             * 
             * C# Programmer Reference: http://msdn.microsoft.com/en-us/library/618ayhy6.aspx
             * C# Operators: http://msdn.microsoft.com/en-us/library/6a71f45d.aspx
             * C# Keywords: http://msdn.microsoft.com/en-us/library/x53a06bb.aspx
             */
        }
    }
}
