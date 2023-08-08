using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using System.Linq;

namespace Task8
{
    public static class UsersWithProducts
    {
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                //.Include(x => x.ProductsSold)   ----> ONLY FOR JUDGE
                //.ToList()
                .Where(x => x.ProductsSold.Any(by => by.BuyerId != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Count(b => b.BuyerId != null),
                        Products = x.ProductsSold
                        .Where(b => b.BuyerId != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                        })
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToList();

            var result = new
            {
                UsersCount = users.Count(),
                Users = users
            };

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver() { NamingStrategy = new CamelCaseNamingStrategy() },
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(result, settings);
        }
    }
}
