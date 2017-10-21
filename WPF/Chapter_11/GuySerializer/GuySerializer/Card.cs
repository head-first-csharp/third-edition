using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuySerializer
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://www.headfirstlabs.com/Chapter11")]
    class Card
    {
        [DataMember]
        public Suits Suit { get; set; }

        [DataMember]
        public Values Value { get; set; }

        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        private static Random r = new Random();

        public static Card RandomCard()
        {
            return new Card((Suits)r.Next(4), (Values)r.Next(1, 14));
        }

        public string Name
        {
            get { return Value.ToString() + " of " + Suit.ToString(); }
        }

        public override string ToString() { return Name; }
    }
}
