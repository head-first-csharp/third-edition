using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobustGuy
{
    class RobustGuy
    {
        public DateTime? Birthday { get; private set; }
        public int? Height { get; private set; }

        public RobustGuy(string birthday, string height)
        {
            DateTime tempDate;
            if (DateTime.TryParse(birthday, out tempDate))
                Birthday = tempDate;
            else
                Birthday = null;

            int tempInt;
            if (int.TryParse(height, out tempInt))
                Height = tempInt;
            else
                Height = null;
        }

        public override string ToString()
        {
            string description;
            if (Birthday.HasValue)
                description = "I was born on " + Birthday.Value.ToLongDateString();
            else
                description = "I don’t know my birthday";
            if (Height.HasValue)
                description += ", and I’m " + Height + " inches tall";
            else
                description += ", and I don’t know my height";
            return description;
        }
    }
}
