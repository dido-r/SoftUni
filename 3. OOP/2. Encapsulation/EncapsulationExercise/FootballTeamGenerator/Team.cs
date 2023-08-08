using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                name = value;
            }
        }

        public double Rating => Math.Round(players.Average(x => x.Stats.Average()));

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.Any(x => x.Name == playerName))
            {
                players.Remove(players.First(x => x.Name == playerName));
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {Name} team.");
            }
        }
    }
}
