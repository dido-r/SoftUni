﻿using BookShop.Data;
using System.Linq;
using System.Text;

namespace BooksByPrice
{
    public static class BooksByPrice
    {
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Select(x => new { x.Title, x.Price })
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }
    }
}
