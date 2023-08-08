using Microsoft.EntityFrameworkCore;
using TaskBoard.Data;
using TaskBoard.Services.Contracts;
using TaskBoard.Services.Models;
using TaskBoardApp.Service.Models;
using TaskBoardApp.Services.Models;
using TaskModel = TaskBoard.Data.Models.Task;

namespace TaskBoard.Services
{
    public class Service : IServices
    {

        private ApplicationDbContext context;

        public Service(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task CreateTask(TaskFormModel model, string userId)
        {
            var task = new TaskModel()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
                OwnerId = userId
            };
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async Task<TaskDetailsModel> FindTaskById(int id)
        {
            var task = await context.Tasks.Where(x => x.Id == id).Select(x => new TaskDetailsModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CreatedOn = x.CreatedOn.ToString(),
                Board = x.Board.Name,
                Owner = x.Owner.UserName,
            }).FirstOrDefaultAsync();

            return task;
        }

        public async Task<TaskFormModel> EditById(int id)
        {
            var current = await context.Tasks.FindAsync(id);
            var task = new TaskFormModel()
            {
                Title = current.Title,
                Description = current.Description,
                BoardId = current.BoardId,
                Boards = await GetBoards()
            };

            return task;
        }

        public async Task EditTask(TaskFormModel model, int id, string userId)
        {
            var current = await context.Tasks.FindAsync(id);

            if (userId != current.OwnerId)
            {
                throw new UnauthorizedAccessException();
            }

            if (current != null)
            {
                current.Title = model.Title;
                current.Description = model.Description;
                current.BoardId = model.BoardId;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BoardViewModel>> GetAll()
        {
            var list = await context
                .Boards
                .Select(x => new BoardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Tasks = x.Tasks.Select(z => new TaskViewModel()
                    {
                        Id = z.Id,
                        Title = z.Title,
                        Description = z.Description,
                        Owner = z.Owner.UserName
                    })
                }).ToListAsync();

            return list;
        }

        public async Task<IEnumerable<TaskBoardModel>> GetBoards()
        {
            return await context.Boards.Select(x => new TaskBoardModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        public async Task DeleteTask(int id, string userId)
        {
            var task = await context.Tasks.FindAsync(id);

            if (userId != task.OwnerId)
            {
                throw new UnauthorizedAccessException();
            }

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
    }
}
