using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Data.Models
{
    public class Board
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DataConstants.BoardMaxName)]
        [MinLength(DataConstants.BoardMinName)]
        public string Name { get; init; } = null!;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
