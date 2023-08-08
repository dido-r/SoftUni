using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Feed(Food food)
        {
            Console.WriteLine("Squeak");

            if (food.FoodType != "Fruit" && food.FoodType != "Vegetable")
            {
                Console.WriteLine($"Mouse does not eat {food.FoodType}!");
            }
            else
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.1;
            }
        }


        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
