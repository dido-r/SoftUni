using TaskBoard.Services.Models;
using TaskBoardApp.Service.Models;
using TaskBoardApp.Services.Models;

namespace TaskBoard.Services.Contracts
{
    public interface IServices
    {
        Task<IEnumerable<BoardViewModel>> GetAll();

        Task<IEnumerable<TaskBoardModel>> GetBoards();

        Task CreateTask(TaskFormModel model, string userId);

        Task<TaskDetailsModel> FindTaskById(int id);

        Task<TaskFormModel> EditById(int id);

        Task EditTask(TaskFormModel model, int id, string userId);

        Task DeleteTask(int id, string userId);
    }
}
