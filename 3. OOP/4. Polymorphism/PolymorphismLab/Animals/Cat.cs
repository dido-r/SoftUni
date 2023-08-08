using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Cat : Animal
    {
        public Cat(string name, string favouriteFood):base(name, favouriteFood)
        {
        }
        public override string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}\nMEEOW";
        }
    }
}
