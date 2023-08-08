using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    public static class UsersImport
    {
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<HashSet<User>>(inputJson);

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
            return $"Successfully imported {context.Users.Count()}";
        }
    }
}
