using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] animalData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var animal = CreateObject.Factory(animalData);
                
                string[] foodData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Food food = new Food(foodData[0], int.Parse(foodData[1]));

                animal.Feed(food);
                animals.Add(animal);
                input = Console.ReadLine();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
