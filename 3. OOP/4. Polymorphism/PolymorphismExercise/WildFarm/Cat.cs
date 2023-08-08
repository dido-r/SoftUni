using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food food)
        {
            Console.WriteLine("Meow");

            if (food.FoodType != "Vegetable" && food.FoodType != "Meat")
            {
                Console.WriteLine($"Cat does not eat {food.FoodType}!");
            }
            else
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.3;
            }
        }

        public override string ToString()
        {
            return $"Cat [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
