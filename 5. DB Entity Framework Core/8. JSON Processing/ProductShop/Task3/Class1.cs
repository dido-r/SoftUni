using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public static class CategoriesImport
    {
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<HashSet<Category>>(inputJson);

            foreach (var category in categories.Where(x => x.Name != null))
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();
            return $"Successfully imported {context.Categories.Count()}";
        }
    }
}
