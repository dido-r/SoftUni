using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> list = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Car car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
                list.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                string[] command = input.Split();
                var currentCar = list.First(x => x.Model == command[1]);
                currentCar.Drive(double.Parse(command[2]));
            }

            foreach (var vehicle in list)
            {
                Console.WriteLine($"{vehicle.Model} {vehicle.FuelAmount:f2} {vehicle.TravelledDistance}");
            }
        }
    }
}
