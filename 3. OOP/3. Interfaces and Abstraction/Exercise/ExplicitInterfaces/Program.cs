using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IResident citizen = new Citizen(data[0], data[1], int.Parse(data[2]));
                IPerson person = new Citizen(data[0], data[1], int.Parse(data[2]));
                Console.WriteLine(person.GetName());
                Console.WriteLine(citizen.GetName());

            }
        }
    }
}
