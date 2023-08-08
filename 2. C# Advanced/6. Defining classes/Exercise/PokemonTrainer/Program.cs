using System;
using System.Linq;
using System.Collections.Generic;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> listOfTrainers = new List<Trainer>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }

                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Pokemon pokemon = new Pokemon(data[1], data[2], int.Parse(data[3]));

                if (listOfTrainers.Any(x => x.Name == data[0]))
                {
                    var currentTrainer = listOfTrainers.First(x => x.Name == data[0]);
                    currentTrainer.ListOfPokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(data[0]);
                    trainer.ListOfPokemons.Add(pokemon);
                    listOfTrainers.Add(trainer);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();


                if (input == "End")
                {
                    break;
                }

                foreach (var guy in listOfTrainers)
                {
                    if (guy.ListOfPokemons.Any(c => c.Element == input))
                    {
                        guy.Badges += 1;
                    }
                    else
                    {
                        guy.ListOfPokemons.ForEach(x => x.Health -= 10);
                        guy.ListOfPokemons = guy.ListOfPokemons.Where(x => x.Health > 0).ToList();
                    }
                }
            }

            foreach (var trainer in listOfTrainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.ListOfPokemons.Count}");
            }
        }
    }
}
