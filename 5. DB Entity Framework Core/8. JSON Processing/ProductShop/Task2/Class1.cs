using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public static class ProductsImport
    {
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<HashSet<Product>>(inputJson);

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
            return $"Successfully imported {context.Products.Count()}";
        }
    }
}
