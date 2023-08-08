using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    public static class CarsImport
    {
        // string inputJson = File.ReadAllText("../../../Datasets/cars.json");
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<HashSet<CarImportDto>>(inputJson);
            var listOfCars = new List<Car>();

            foreach (var item in carsDto)
            {
                var car = new Car
                {
                    Make = item.Make,
                    Model = item.Model,
                    TravelledDistance = item.TravelledDistance
                };

                foreach (var part in item.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar { PartId = part });
                }

                listOfCars.Add(car);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }
    }
}
