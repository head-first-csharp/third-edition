using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketballRoster.ViewModel
{
    using Model;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    class RosterViewModel
    {
        public ObservableCollection<PlayerViewModel> Starters { get; set; }
        public ObservableCollection<PlayerViewModel> Bench { get; set; }

        private Roster _roster;


        private string _teamName;
        public string TeamName
        {
            get { return _teamName; }
            set
            {
                _teamName = value;
            }
        }

        public RosterViewModel(Roster roster)
        {
            _roster = roster;

            Starters = new ObservableCollection<PlayerViewModel>();
            Bench = new ObservableCollection<PlayerViewModel>();

            TeamName = _roster.TeamName;

            UpdateRosters();
        }

        private void UpdateRosters()
        {
            var startingPlayers =
                from player in _roster.Players
                where player.Starter
                select player;

            foreach (Player player in startingPlayers)
                Starters.Add(new PlayerViewModel(player.Name, player.Number));

            var benchPlayers =
                from player in _roster.Players
                where player.Starter == false
                select player;

            foreach (Player player in benchPlayers)
                Bench.Add(new PlayerViewModel(player.Name, player.Number));
        }
    }
}