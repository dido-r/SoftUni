using BookShop.Data;
using System.Linq;
using System.Text;

namespace TotalBookCopies
{
    public static class TotalBookCopies
    {
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(x => new { x.FirstName, x.LastName, Copies = x.Books.Sum(x => x.Copies) })
                .OrderByDescending(x => x.Copies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");
            }

            return sb.ToString().Trim();
        }
    }
}
