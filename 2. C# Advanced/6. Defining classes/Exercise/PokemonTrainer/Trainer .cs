using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> ListOfPokemons { get; set; }

        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            ListOfPokemons = new List<Pokemon>();
        }
    }
}
