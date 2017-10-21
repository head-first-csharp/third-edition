using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leftover7
{
    class SportCollection_MANUAL : IEnumerable<Sport>
    {
        public IEnumerator<Sport> GetEnumerator()
        {
            return new ManualSportEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        class ManualSportEnumerator : IEnumerator<Sport>
        {
            int current = -1;
            public Sport Current { get { return (Sport)current; } }
            public void Dispose() { return; } // Nothing to dispose
            object System.Collections.IEnumerator.Current { get { return Current; } }
            public bool MoveNext()
            {
                int maxEnumValue = Enum.GetValues(typeof(Sport)).Length - 1;
                if ((int)current >= maxEnumValue)
                    return false;
                current++;
                return true;
            }
            public void Reset() { current = 0; }
        }
    }
}
