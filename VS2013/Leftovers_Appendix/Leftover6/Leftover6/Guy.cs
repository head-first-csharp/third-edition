using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover6
{
    /// <summary>
    /// A guy with a name, age and a wallet full of bucks
    /// </summary>
    public class Guy
    {
        /*
         * Notice how Name and Age are properties with backing fields that are
         * marked readonly. That means those backing fields can only be set when 
         * the object is initialized (in their declarations or in the constructor). 
         */

        /// <summary>
        /// Read-only backing field for the Name property
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The name of the guy
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Read-only backing field for the Age property
        /// </summary>
        private readonly int age;

        /// <summary>
        /// The guy's age
        /// </summary>
        public int Age { get { return age; } }

        /*
         * Cash is not readonly because it might change during the life of the Guy.
         */

        /// <summary>
        /// The number of bucks the guy has
        /// </summary>
        public int Cash { get; private set; }

        /// <summary>
        /// The constructor sets the name, age and cash
        /// </summary>
        /// <param name="name">The name of the guy</param>
        /// <param name="age">The guy's age</param>
        /// <param name="cash">The amount of cash the guy starts with</param>
        public Guy(string name, int age, int cash)
        {
            this.name = name;
            this.age = age;
            Cash = cash;
        }

        public override string ToString()
        {
            return String.Format("{0} is {1} years old and has {2} bucks", Name, Age, Cash);
        }

        /// <summary>
        /// Give cash from my wallet
        /// </summary>
        /// <param name="amount">The amount of cash to give</param>
        /// <returns>The amount of cash I gave, or 0 if I don't have enough cash</returns>
        public int GiveCash(int amount)
        {
            if (amount <= Cash && amount > 0)
            {
                Cash -= amount;
                return amount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Receive some cash into my wallet
        /// </summary>
        /// <param name="amount">Amount to receive</param>
        /// <returns>The amount of cash received, or 0 if no cash was received</returns>
        public int ReceiveCash(int amount)
        {
            if (amount > 0)
            {
                Cash += amount;
                return amount;
            }
            Console.WriteLine("{0} says: {1} isn't an amount I'll take", Name, amount);
            return 0;
        }
    }
}
