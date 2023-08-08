using BookShop.Data;
using System.Text;
using System.Linq;

namespace IncreasePrices
{
    public static class IncreasePrice
    {
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
    }
}
