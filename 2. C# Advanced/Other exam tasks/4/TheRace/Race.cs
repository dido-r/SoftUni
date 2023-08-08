using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data = new List<Racer>();

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public void Add(Racer Racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(Racer);
            }
        }
        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                data.Remove(data.First(x => x.Name == name));
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            return data.First(x => x.Age == data.Max(y => y.Age));
        }
        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }
        public Racer GetFastestRacer()
        {
            return data.First(x => x.Car.Speed == data.Max(y => y.Car.Speed));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in data)
            {
                sb.AppendLine($"{racer}");
            }
            return sb.ToString().Trim();
        }
    }
}
