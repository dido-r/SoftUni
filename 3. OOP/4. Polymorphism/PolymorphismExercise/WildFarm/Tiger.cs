using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food food)
        {
            Console.WriteLine("ROAR!!!");

            if (food.FoodType != "Meat")
            {
                Console.WriteLine($"Tiger does not eat {food.FoodType}!");
            }
            else
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity;
            }
        }

        public override string ToString()
        {
            return $"Tiger [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
