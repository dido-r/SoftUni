using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Database.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; } = null!;
    }
}
