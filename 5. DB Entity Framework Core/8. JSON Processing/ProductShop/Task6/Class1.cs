using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using System.Linq;

namespace Task6
{
    public static class SoldProducts
    {
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any(by => by.BuyerId != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold
                    .Where(b => b.BuyerId != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver() { NamingStrategy = new CamelCaseNamingStrategy() },
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(users, settings);
        }
    }
}
