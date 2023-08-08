using ASP.NET.Database.Database;
using ASP.NET.Database.Models;
using ASP.NET.Services.Models;
using ASP.NET.Services.Services.Ìnterfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Services.Services
{
    public class ProductServices : IPropductServices
    {
        private ProductDbContext context;

        public ProductServices(ProductDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task AddProductsAsync(ProductViewModel product)
        {
            var newProduct = new Product
            {
                ProductName = product.ProductName
            };

            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductsAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product != null)
            {
                context.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditProductsAsync(int id, ProductViewModel product)
        {
            var currentProduct = await context.Products.FindAsync(id);

            if (currentProduct != null)
            {
                currentProduct.ProductName = product.ProductName;
                await context.SaveChangesAsync();
            }
        }

        public async Task<ProductViewModel> GetCurrentProductAsync(int id)
        {
            var product = await context.Products.FindAsync(id);
            var newProduct = new ProductViewModel
            {
                ProductName = product.ProductName
            };

            return newProduct;
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            return await context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName
            }).ToListAsync();
        }
    }
}
