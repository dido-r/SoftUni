using Library.Data;
using Library.Data.Models;
using Library.Services.Contracts;
using Library.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Provider
{
    public class Service : IServices
    {
        private LibraryDbContext context;
        public Service(LibraryDbContext db)
        {
            context = db;
        }

        public async Task AddToCollection(int id, string userId)
        {
            var book = await context
                .IdentityUsersBooks
                .FirstOrDefaultAsync(x => x.CollectorId == userId && x.BookId == id);

            if (book == null)
            {
                var pair = new IdentityUserBook()
                {
                    BookId = id,
                    CollectorId = userId,
                };

                await context.IdentityUsersBooks.AddAsync(pair);
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateBook(BookFormModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooks()
        {
            return await context
                .Books
                .Select(book => new BookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    Rating = book.Rating,
                    Category = book.Category.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<CategoryFormModel>> GetCategories()
        {
            return await context
                .Categories
                .Select(x => new CategoryFormModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetMineBooks(string userId)
        {
            var list = context
                .IdentityUsersBooks
                .Where(x => x.CollectorId == userId);

            if (list.Any())
            {
                return await list.Select(x => new BookViewModel()
                {
                    Id = x.BookId,
                    Title = x.Book.Title,
                    Author = x.Book.Author,
                    Description = x.Book.Description,
                    ImageUrl = x.Book.ImageUrl,
                    Rating = x.Book.Rating,
                    Category = x.Book.Category.Name
                }).ToListAsync();
            }

            return new List<BookViewModel>();
        }

        public async Task RemoveFromCollection(int id, string userId)
        {
            var book = await context
                .IdentityUsersBooks
                .FirstAsync(x => x.BookId == id && x.CollectorId == userId);

            if (book != null)
            {
                context
                    .IdentityUsersBooks
                    .Remove(book);

                await context.SaveChangesAsync();
            }
        }
    }
}
