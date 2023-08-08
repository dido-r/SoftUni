using BookShop.Data;
using System.Linq;

namespace CountBooks
{
    public static class CountBook
    {
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var authors = context
                .Books
                .Count(x => x.Title.Length > lengthCheck);

            return authors;
        }
    }
}
