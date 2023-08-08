using BookShop.Data;
using System.Linq;
using System.Text;

namespace GoldenBooks
{
    public static class GoldenBooks
    {
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Select(x => new { x.BookId, x.Title, x.EditionType, x.Copies })
                .Where(x => x.Copies < 5000)
                .ToList()
                .Where(x => x.EditionType.ToString() == "Gold")
                .OrderBy(x => x.BookId);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().Trim();
        }
    }
}
