using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Feed(Food food)
        {
            Console.WriteLine("Woof!");

            if (food.FoodType != "Meat")
            {
                Console.WriteLine($"Dog does not eat {food.FoodType}!");
            }
            else
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.4;
            }
        }

        public override string ToString()
        {
            return $"Dog [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
