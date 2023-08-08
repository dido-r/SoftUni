using System.ComponentModel.DataAnnotations;

namespace Library.Services.Models
{
    public class BookFormModel
    {

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryFormModel> Categories { get; set; } = new List<CategoryFormModel>();
    }
}
