using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> list = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 4)
                {
                    IBuyer citizen = new Citizen(data[0], int.Parse(data[1]), data[2], data[3]);
                    list.Add(citizen);
                }
                else if (data.Length == 3)
                {
                    IBuyer rebel = new Rebel(data[0], int.Parse(data[1]), data[2]);
                    list.Add(rebel);
                }
            }

            string name = Console.ReadLine();

            while (name != "End")
            {
                if (list.Any(x => x.Name == name))
                {
                    list.First(x => x.Name == name).BuyFood();
                }
                name = Console.ReadLine();
            }

            Console.WriteLine(list.Sum(x => x.Food));
        }
    }
}
