using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Range(1,100)]
        public decimal Price  { get; set; }

        [Required]
        [Range(1, 10)]
        public sbyte RowNumber  { get; set; }

        [Required]
        public int PlayId { get; set; }

        public virtual Play Play { get; set; }

        [Required]
        public int TheatreId  { get; set; }

        public virtual Theatre Theatre { get; set; }
    }
}
