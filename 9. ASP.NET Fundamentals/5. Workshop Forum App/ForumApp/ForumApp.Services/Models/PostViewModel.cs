using System.ComponentModel.DataAnnotations;

namespace ForumApp.Services.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(1500, MinimumLength = 30)]
        public string Content { get; set; } = null!;
    }
}
