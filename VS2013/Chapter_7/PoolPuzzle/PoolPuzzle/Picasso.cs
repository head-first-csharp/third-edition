using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolPuzzle
{
    abstract class Picasso : INose
    {
        public virtual int Ear()
        {
            return 7;
        }
        public Picasso(string face)
        {
            this.face = face;
        }
        public virtual string Face
        {
            get { return face; }
        }
        string face;
    }
}
