using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count != n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                var hero = Create.CreateHero(type, name);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    heroes.Add(hero);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            foreach (var raider in heroes)
            {
                Console.WriteLine(raider.CastAbility());
            }

            if (heroes.Sum(x => x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
