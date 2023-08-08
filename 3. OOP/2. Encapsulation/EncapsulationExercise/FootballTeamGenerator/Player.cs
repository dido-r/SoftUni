using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int[] stats;

        public Player(string name, params int[] stats)
        {
            Name = name;
            Stats = stats;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                name = value;
            }
        }
        public int[] Stats 
        {
            get { return stats; }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] < 0 || value[i] > 100)
                    {
                        string item = string.Empty;
                        if (i == 0) item = "Endurance";
                        if (i == 1) item = "Sprint";
                        if (i == 2) item = "Dribble";
                        if (i == 3) item = "Passing";
                        if (i == 4) item = "Shooting";
                        throw new Exception($"{item} should be between 0 and 100.");
                    }
                }
                stats = value;
            }
        }
    }
}
