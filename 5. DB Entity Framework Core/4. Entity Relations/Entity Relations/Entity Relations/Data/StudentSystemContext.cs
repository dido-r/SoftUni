using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .Property(x => x.PhoneNumber)
                .IsUnicode(false);

            modelBuilder
                .Entity<Resource>()
                .Property(x => x.Url)
                .IsUnicode(false);

            modelBuilder
                .Entity<Homework>()
                .Property(x => x.Content)
                .IsUnicode(false);

            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(x => new { x.StudentId, x.CourseId});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-I51906\SQLEXPRESS;Database=StudentSystem;Integrated Security=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
