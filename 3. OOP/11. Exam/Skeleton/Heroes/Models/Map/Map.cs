using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = players.Where(x => x.GetType().Name == "Knight").ToList();
            var barbarians = players.Where(x => x.GetType().Name == "Barbarian").ToList();

            while (true)
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        foreach (var barbarian in barbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(knight.Weapon.DoDamage());
                            }
                        }
                    }
                }

                if (!barbarians.Any(x => x.IsAlive == true))
                {
                    break;
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        foreach (var knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barbarian.Weapon.DoDamage());
                            }
                        }
                    }
                }
                if (!knights.Any(x => x.IsAlive == true))
                {
                    break;
                }
            }

            if (!knights.Any(x => x.IsAlive == true))
            {
                return $"The barbarians took {barbarians.Count(x => x.IsAlive == false)} casualties but won the battle.";
            }

            return $"The knights took {knights.Count(x => x.IsAlive == false)} casualties but won the battle.";
        }
    }
}
