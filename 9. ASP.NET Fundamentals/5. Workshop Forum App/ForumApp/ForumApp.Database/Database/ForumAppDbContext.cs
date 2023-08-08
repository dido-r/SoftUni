using ForumApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Database.Database
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Posts { get; init; }
    }
}
