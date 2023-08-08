using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Data.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TaskMaxTitle)]
        [MinLength(DataConstants.TaskMinTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.TaskMaxDescription)]
        [MinLength(DataConstants.TaskMinDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public IdentityUser Owner { get; set; }
    }
}
