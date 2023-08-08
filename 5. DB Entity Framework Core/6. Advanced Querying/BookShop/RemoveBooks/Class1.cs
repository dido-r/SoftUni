using BookShop.Data;
using System.Linq;

namespace RemoveBooks
{
    public static class RemoveBook
    {
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(x => x.Copies < 4200)
                .ToList();

            int count = 0;

            foreach (var book in books)
            {
                if (context.Books.Contains(book))
                {
                    context.Books.Remove(book);
                    count++;
                }
            }

            context.SaveChanges();

            return count;
        }
    }
}
