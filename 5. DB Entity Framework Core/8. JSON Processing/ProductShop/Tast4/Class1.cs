using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tast4
{
    public static class CategoryProductsImport
    {
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProduct = JsonConvert.DeserializeObject<HashSet<CategoryProduct>>(inputJson);

            foreach (var pair in categoriesProduct)
            {
                context.CategoryProducts.Add(pair);
            }

            context.SaveChanges();
            return $"Successfully imported {context.CategoryProducts.Count()}";
        }
    }
}
