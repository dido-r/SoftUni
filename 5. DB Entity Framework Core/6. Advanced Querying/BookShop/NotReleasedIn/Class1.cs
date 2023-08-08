using BookShop.Data;
using System.Linq;
using System.Text;

namespace NotReleasedIn
{
    public static class NotReleasedIn
    {
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Select(x => new { x.BookId, x.Title, x.ReleaseDate })
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().Trim();
        }
    }
}
