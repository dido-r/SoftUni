using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace MostRecentBooks
{
    public static class Class1
    {
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .Include(x => x.CategoryBooks)
                .ThenInclude(x => x.Book)
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var item in category.CategoryBooks.OrderByDescending(x => x.Book.ReleaseDate).Take(3))
                {
                    sb.AppendLine($"{item.Book.Title} ({item.Book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
