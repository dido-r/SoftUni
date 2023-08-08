using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoard.Services.Contracts;
using TaskBoardApp.Service.Models;

namespace TaskBoard.Controllers
{
    public class TaskController : Controller
    {
        private IServices services;
        public TaskController(IServices _services)
        {
            services = _services;
        }

        public async Task<IActionResult> Create()
        {
            var model = new TaskFormModel()
            {
                Boards = await services.GetBoards(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            var userId = GetUserId();
            await services.CreateTask(model, userId);
            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await services.FindTaskById(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await services.EditById(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskFormModel model, int id)
        {
            var userId = GetUserId();

            try
            {
                await services.EditTask(model, id, userId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await services.EditById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskFormModel model, int id)
        {
            var userId = GetUserId();

            try
            {
                await services.DeleteTask(id, userId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return RedirectToAction("All", "Board");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
