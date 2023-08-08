using System.ComponentModel.DataAnnotations;

namespace TextSplitterApp.Models
{
    public class TextViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Text { get; set; }

        public string SplitText { get; set; }
    }
}
