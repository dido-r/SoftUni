using CarDealer.Data;
using Newtonsoft.Json;
using System.Linq;

namespace Task6
{
    public static class OrderedCustomers
    {
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                 .Customers
                 .Select(x => new
                 {
                     Name = x.Name,
                     BirthDate = x.BirthDate,
                     IsYoungDriver = x.IsYoungDriver
                 })
                 .OrderBy(x => x.BirthDate)
                 .ThenBy(x => x.IsYoungDriver)
                 .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "dd/MM/yyyy",
            };

            return JsonConvert.SerializeObject(customers, settings);
        }
    }
}
