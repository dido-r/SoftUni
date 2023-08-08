using BookShop.Data;
using System.Linq;
using System.Text;

namespace BookSearchByAuthor
{
    public static class BookSearchByAuthor
    {
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Select(x => new { x.BookId, x.Title, x.Author.FirstName, x.Author.LastName })
                .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString().Trim();
        }
    }
}
