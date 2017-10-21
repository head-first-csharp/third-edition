using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRoster.Model
{
    class Roster
    {
        public string TeamName { get; private set; }

        private readonly List<Player> _players = new List<Player>();
        public IEnumerable<Player> Players
        {
            get { return new List<Player>(_players); }
        }

        public Roster(string teamName, IEnumerable<Player> players)
        {
            TeamName = teamName;
            _players.AddRange(players);
        }
    }
}
