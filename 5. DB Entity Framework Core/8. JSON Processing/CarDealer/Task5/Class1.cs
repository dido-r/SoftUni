using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Task5
{
    public static class SalesImport
    {
        //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salses = JsonConvert.DeserializeObject<HashSet<Sale>>(inputJson);
            context.Sales.AddRange(salses);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }
    }
}
