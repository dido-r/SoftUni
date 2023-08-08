using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> list;

        public AstronautRepository()
        {
            list = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => list.AsReadOnly();

        public void Add(IAstronaut model)
        {
            list.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return list.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
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
