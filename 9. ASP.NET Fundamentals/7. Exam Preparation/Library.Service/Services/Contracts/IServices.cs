using Library.Services.Models;

namespace Library.Services.Contracts
{
    public interface IServices
    {
        Task<IEnumerable<CategoryFormModel>> GetCategories();

        Task CreateBook(BookFormModel model);

        Task<IEnumerable<BookViewModel>> GetAllBooks();

        Task<IEnumerable<BookViewModel>> GetMineBooks(string userId);

        Task AddToCollection(int id, string userId);

        Task RemoveFromCollection(int id, string userId);
    }
}
