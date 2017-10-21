using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoeChapter10
{
    class MenuItem
    {
        public string Meat { get; private set; }
        public string Condiment { get; private set; }
        public string Bread { get; private set; }

        public MenuItem(string meat, string condiment, string bread)
        {
            Meat = meat;
            Condiment = condiment;
            Bread = bread;
        }

        public override string ToString()
        {
            return Meat + " with " + Condiment + " on " + Bread;
        }
    }
}
