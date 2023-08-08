using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> list;

        public PlanetRepository()
        {
            list = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => list.AsReadOnly();

        public void Add(IPlanet model)
        {
            list.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return list.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            if (list.Any(x => x.Name == model.Name))
            {
                list.Remove(model);
                return true;
            }

            return false;
        }
    }
}
