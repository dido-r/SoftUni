using BookShop.Data;
using System;
using System.Linq;
using System.Text;

namespace ReleasedBeforeDate
{
    public static class ReleasedBeforeDate
    {
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            string[] data = date.Split("-", StringSplitOptions.RemoveEmptyEntries);
            var inputToDate = new DateTime(int.Parse(data[2]), int.Parse(data[1]), int.Parse(data[0]));

            var books = context
                .Books
                .Select(x => new { x.Title, x.ReleaseDate, x.Price, x.EditionType })
                .Where(x => x.ReleaseDate < inputToDate)
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }
    }
}
