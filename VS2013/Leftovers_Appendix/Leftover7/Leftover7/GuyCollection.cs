using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover7
{
    class GuyCollection : IEnumerable<Guy>
    {
        private static readonly Dictionary<string, int> namesAndAges = new Dictionary<string, int>()
    {
            {"Joe", 41}, {"Bob", 43}, {"Ed", 39}, {"Larry", 44}, {"Fred", 45}
    };
        public IEnumerator<Guy> GetEnumerator()
        {
            Random random = new Random();
            int pileOfCash = 125 * namesAndAges.Count;
            int count = 0;
            foreach (string name in namesAndAges.Keys)
            {
                int cashForGuy = (++count < namesAndAges.Count) ? random.Next(125) : pileOfCash;
                pileOfCash -= cashForGuy;
                yield return new Guy(name, namesAndAges[name], cashForGuy);
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Gets or sets the age of a given guy
        /// </summary>
        /// <param name="name">Name of the guy</param>
        /// <returns>Age of the guy</returns>
        public int this[string name]
        {
            get
            {
                if (namesAndAges.ContainsKey(name))
                    return namesAndAges[name];
                throw new KeyNotFoundException("Name " + name + " was not found");
            }
            set
            {
                if (namesAndAges.ContainsKey(name))
                    namesAndAges[name] = value;
                else
                    namesAndAges.Add(name, value);
            }
        }
    }
}
