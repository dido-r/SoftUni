using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => drones.Count;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            drones = new List<Drone>();
        }

        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Brand == null || drone.Range < 5 || drone.Range > 15)
            {
                return  "Invalid drone.";
            }
            else if (drones.Count >= Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }
        public bool RemoveDrone(string name)
        {
            if (drones.Any(x => x.Name == name))
            {
                drones.Remove(drones.First(x => x.Name == name));
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            if (drones.Any(x => x.Brand == brand))
            {
                int count = drones.Count(c => c.Brand == brand);
                drones.RemoveAll(y => y.Brand == brand);
                return count;
            }
            return 0;
        }
        public Drone FlyDrone(string name)
        {
            if (drones.Any(x => x.Name == name))
            {
                var curretDrone = drones.First(x => x.Name == name);
                curretDrone.Available = false;
                return curretDrone;
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (var item in drones.Where(x => x.Range >= range))
            {
                item.Available = false;
            }
            return drones.Where(x => x.Range >= range).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");

            foreach (var drone in drones.Where(x => x.Available == true))
            {
                sb.AppendLine($"{drone}");
            }
            return sb.ToString().Trim();
        }
    }
}
