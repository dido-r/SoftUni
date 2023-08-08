using BookShop.Data;
using System.Linq;
using System.Text;

namespace ProfitByCategory
{
    public static class ProfitByCategory
    {
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(x => new { x.Name, Profit = x.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price) })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return sb.ToString().Trim();
        }
    }
}
