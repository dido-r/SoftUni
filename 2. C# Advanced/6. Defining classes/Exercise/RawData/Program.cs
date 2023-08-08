using System;
using System.Linq;
using System.Collections.Generic;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> list = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Engine engine = new Engine(int.Parse(data[1]), int.Parse(data[2]));
                Cargo cargo = new Cargo(data[4], int.Parse(data[3]));
                Tire[] tire = new Tire[4];
                int index = 0;

                for (int j = 5; j < data.Length; j += 2)
                {
                    Tire currentTire = new Tire(double.Parse(data[j]), int.Parse(data[j + 1]));
                    tire[index++] = currentTire;
                }

                Car car = new Car(data[0], engine, cargo, tire);
                list.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in list.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tire.Any(c => c.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in list.Where(x => x.Cargo.Type == "flammable").Where(x => x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
