using ASP.NET.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Database.Database
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
