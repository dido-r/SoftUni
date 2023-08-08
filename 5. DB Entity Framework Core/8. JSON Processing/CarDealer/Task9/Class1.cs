using CarDealer.Data;
using Newtonsoft.Json;
using System.Linq;

namespace Task9
{
    public static class CarsWithTheirListOfParts
    {
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance,
                    },

                    parts = new
                    {
                        x.PartCars
                    }
                    .PartCars
                    .Select(z => new
                    {
                        Name = z.Part.Name,
                        Price = z.Part.Price.ToString("F2")
                    })
                })
                .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(cars, settings);
        }
    }
}
