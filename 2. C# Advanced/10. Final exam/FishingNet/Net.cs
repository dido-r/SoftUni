using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => fish.Count;
        public IReadOnlyCollection<Fish> Fish => fish; 

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " " || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if (Count == Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                this.fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            if (fish.Any(x => x.Weight == weight))
            {
                fish.Remove(fish.First(x => x.Weight == weight));
                return true;
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            return fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return fish.First(x => x.Length == fish.Max(c => c.Length));
        }

        public string Report()
        {
            StringBuilder net = new StringBuilder();
            net.AppendLine($"Into the {Material}:");

            foreach (var item in fish.OrderByDescending(x => x.Length))
            {
                net.AppendLine($"{item}");
            }
            return net.ToString().Trim();
        }
    }
}
