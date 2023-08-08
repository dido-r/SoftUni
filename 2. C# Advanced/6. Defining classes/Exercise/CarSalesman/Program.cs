using System;
using System.Linq;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Engine> enginesList = new List<Engine>();
            List<Car> carsList = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(engineData[0], int.Parse(engineData[1]));
                if (engineData.Length == 3)
                {
                    int number;
                    bool successfullyParsed = int.TryParse(engineData[2], out number);
                    if (successfullyParsed)
                    {
                        engine.Displacement = int.Parse(engineData[2]);
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }
                }
                else if (engineData.Length == 4)
                {
                    engine.Displacement = int.Parse(engineData[2]);
                    engine.Efficiency = engineData[3];
                }

                enginesList.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var currentEngine = enginesList.First(x => x.Model == carData[1]);
                Car car = new Car(carData[0], currentEngine);
                if (carData.Length == 3)
                {
                    int number;
                    bool successfullyParsed = int.TryParse(carData[2], out number);
                    if (successfullyParsed)
                    {
                        car.Weight = int.Parse(carData[2]);
                    }
                    else
                    {
                        car.Color = carData[2];
                    }
                }
                else if (carData.Length == 4)
                {
                    car.Weight = int.Parse(carData[2]);
                    car.Color = carData[3];
                }
                carsList.Add(car);
            }

            foreach (var car in carsList)
            {
                if (car.Engine.Efficiency == null)
                {
                    car.Engine.Efficiency = "n/a";
                }
                if (car.Color == null)
                {
                    car.Color = "n/a";
                }

                Console.WriteLine($"{car.Name}:");
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"   Power: {car.Engine.Power}");
                if (car.Engine.Displacement != 0)
                {
                    Console.WriteLine($"   Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine("   Displacement: n/a");
                }
                Console.WriteLine($"   Efficiency: {car.Engine.Efficiency}");
                if (car.Weight != 0)
                {
                    Console.WriteLine($" Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine(" Weight: n/a");
                }
                Console.WriteLine($" Color: {car.Color}");
            }
        }
    }
}
