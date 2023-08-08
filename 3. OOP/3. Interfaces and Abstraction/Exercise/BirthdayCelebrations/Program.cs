using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthable> list = new List<IBirthable>();

            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Citizen")
                {
                    IBirthable human = new Citizen(data[1], int.Parse(data[2]), data[3], data[4]);
                    list.Add(human);
                }
                else if (data[0] == "Pet")
                {
                    IBirthable pet = new Pet(data[1], data[2]);
                    list.Add(pet);
                }
                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var item in list)
            {
                if (item.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
