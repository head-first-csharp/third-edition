using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover6
{
    /// <summary>
    /// A guy that knows how to compare itself with other guys
    /// </summary>
    class EquatableGuy : Guy, IEquatable<Guy>
    {

        public EquatableGuy(string name, int age, int cash)
            : base(name, age, cash) { }

        /// <summary>
        /// Compare this object against another EquatableGuy
        /// </summary>
        /// <param name="other">The EquatableGuy object to compare with</param>
        /// <returns>True if the objects have the same values, false otherwise</returns>
        public bool Equals(Guy other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && other.Age == Age && other.Cash == Cash;
        }

        /// <summary>
        /// Override the Equals method and have it call Equals(Guy)
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>True if the value of the other object is equal to this one</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Guy)) return false;
            return Equals((Guy)obj);
        }


        /// <summary>
        /// Part of the contract for overriding Equals is that you need to override
        /// GetHashCode() as well. It should compare the values and return true
        /// if the values are equal.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            const int prime = 397;
            int result = Age;
            result = (result * prime) ^ (Name != null ? Name.GetHashCode() : 0);
            result = (result * prime) ^ Cash;
            return result;
        }
    }
}
