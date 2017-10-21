using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowCalculator
{
    class Farmer
    {
        // BagsOfFeed field removed on page 225 and replaced with an automatic property
        // public int BagsOfFeed;

        public int BagsOfFeed { get; private set; }

        // Replaced constant with a property and backing field on page 226
        // public const int FeedMultiplier = 30;

        private int feedMultiplier;
        public int FeedMultiplier { get { return feedMultiplier; } }


        public Farmer(int numberOfCows, int feedMultiplier)
        {
            this.feedMultiplier = feedMultiplier;
            NumberOfCows = numberOfCows;
        } 

        private int numberOfCows;
        public int NumberOfCows
        {
            get
            {
                return numberOfCows;
            }
            set
            {
                numberOfCows = value;
                BagsOfFeed = numberOfCows * FeedMultiplier;
            }
        }
    }
}
