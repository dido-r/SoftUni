using System.ComponentModel.DataAnnotations;
using TaskBoard.Data;

namespace TaskBoardApp.Service.Models
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(DataConstants.TaskMaxTitle, MinimumLength = DataConstants.TaskMinTitle,
            ErrorMessage = "Title should be at least {2} characters long")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.TaskMaxDescription, MinimumLength = DataConstants.TaskMinDescription,
            ErrorMessage = "Description should be at least {2} characters long")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
    }
}
