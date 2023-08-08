using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> engineList = new List<Engine>();
            List<Car> cars = new List<Car>();

            while (true)
            {
                string tireInfo = Console.ReadLine();

                if (tireInfo == "No more tires")
                {
                    break;
                }
                string[] tireData = tireInfo.Split();
                var allFourTires = new Tire[tireData.Length / 2];
                int index = 0;

                for (int i = 0; i < tireData.Length; i += 2)
                {
                    Tire currentTire = new Tire(int.Parse(tireData[i]), double.Parse(tireData[i + 1]));
                    allFourTires[index++] = currentTire;
                }
                tiresList.Add(allFourTires);
            }

            while (true)
            {
                string engineInfo = Console.ReadLine();

                if (engineInfo == "Engines done")
                {
                    break;
                }
                string[] engineData = engineInfo.Split();
                Engine currentEngine = new Engine(int.Parse(engineData[0]), double.Parse(engineData[1]));
                engineList.Add(currentEngine);
            }

            while (true)
            {
                string carInfo = Console.ReadLine();

                if (carInfo == "Show special")
                {
                    break;
                }
                string[] data = carInfo.Split();
                Car car = new Car(data[0], data[1], int.Parse(data[2]), double.Parse(data[3]), double.Parse(data[4]));
                car.Engine = engineList[int.Parse(data[5])];
                car.Tire = tiresList[int.Parse(data[6])];
                cars.Add(car);
            }

            foreach (var item in cars.Where(x => x.Year >= 2017).Where(x => x.Engine.HorsePower >= 330).Where(x => (x.Tire.Sum(c => c.Pressure) >= 9) && (x.Tire.Sum(c => c.Pressure) <= 10)))
            {
                item.Drive(20);
                Console.WriteLine($"Make: {item.Make}");
                Console.WriteLine($"Model: {item.Model}");
                Console.WriteLine($"Year: {item.Year}");
                Console.WriteLine($"HorsePowers: {item.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {item.FuelQuantity}");
            }
        }
    }
}
