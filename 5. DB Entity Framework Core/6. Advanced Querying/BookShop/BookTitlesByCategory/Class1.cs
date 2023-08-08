using BookShop.Data;
using System;
using System.Linq;
using System.Text;

namespace BookTitlesByCategory
{
    public static class GetBooksTitleByCategory
    {
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context
                .BooksCategories
                .Select(x => new { Title = x.Book.Title, Category = x.Category.Name })
                .OrderBy(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                if (categories.Contains(book.Category.ToLower()))
                {
                    sb.AppendLine($"{book.Title}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
