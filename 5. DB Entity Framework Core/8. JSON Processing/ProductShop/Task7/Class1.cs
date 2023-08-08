using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using System.Linq;

namespace Task7
{
    public static class CategoriesByProductsCount
    {
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                 .Categories
                 .Select(x => new
                 {
                     Category = x.Name,
                     ProductsCount = x.CategoryProducts.Count(),
                     AveragePrice = x.CategoryProducts.Count == 0 ? 0.ToString("F2") : x.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                     TotalRevenue = x.CategoryProducts.Sum(s => s.Product.Price).ToString("F2")
                 })
                 .OrderByDescending(x => x.ProductsCount)
                 .ToList();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver() { NamingStrategy = new CamelCaseNamingStrategy() },
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(categories, settings);
        }
    }
}
