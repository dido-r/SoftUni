using ASP.NET.Services.Models;

namespace ASP.NET.Services.Services.Ìnterfaces
{
    public interface IPropductServices
    {
        Task<List<ProductViewModel>> GetProductsAsync();

        Task<ProductViewModel> GetCurrentProductAsync(int id);

        Task AddProductsAsync(ProductViewModel product);

        Task EditProductsAsync(int id, ProductViewModel product);

        Task DeleteProductsAsync(int id);
    }
}
