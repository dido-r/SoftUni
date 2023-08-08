using CarDealer.Data;
using Newtonsoft.Json;
using System.Linq;

namespace Task11
{
    public static class SalesWithAppliedDiscount
    {
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },

                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(z => z.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(z => z.Part.Price) * (1 - (x.Discount / 100))).ToString("F2")
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}
