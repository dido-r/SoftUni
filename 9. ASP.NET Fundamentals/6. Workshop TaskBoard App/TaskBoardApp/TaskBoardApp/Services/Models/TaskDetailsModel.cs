using TaskBoard.Services.Models;

namespace TaskBoardApp.Services.Models
{
    public class TaskDetailsModel : TaskViewModel
    {

        public string CreatedOn { get; init; } = null!;

        public string Board { get; init; } = null!;
    }
}
