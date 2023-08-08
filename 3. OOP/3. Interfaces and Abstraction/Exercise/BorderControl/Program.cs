using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IIdentifiable> list = new List<IIdentifiable>();

            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 2)
                {
                    IIdentifiable robot = new Robot(data[0], data[1]);
                    list.Add(robot);
                }
                else
                {
                    IIdentifiable human = new Citizen(data[0], int.Parse(data[1]), data[2]);
                    list.Add(human);
                }
                input = Console.ReadLine();
            }

            string validator = Console.ReadLine();

            foreach (var item in list)
            {
                item.Validate(validator);
            }

            Console.WriteLine(string.Join("\n", list.Where(x => x.Id != null).Select(x => x.Id)));
        }
    }
}
