using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Mail
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"[a-z,A-Z,0-9,\s,\S]*( str.)")]
        public string Address { get; set; }

        public int PrisonerId { get; set; }

        [Required]
        public virtual Prisoner Prisoner { get; set; }
    }
}
