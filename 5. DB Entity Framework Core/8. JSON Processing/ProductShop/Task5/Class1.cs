using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using System.Linq;

namespace Task5
{
    public static class ProductsInRange
    {
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Select(x => new { x.Name, x.Price, Seller = string.Concat(x.Seller.FirstName, " ", x.Seller.LastName) })
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver() { NamingStrategy = new CamelCaseNamingStrategy() },
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(products, settings);
        }
    }
}
