using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Services.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;
    }
}
