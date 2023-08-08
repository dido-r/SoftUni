using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Contracts;

namespace TaskBoard.Controllers
{
    public class BoardController : Controller
    {
        private IServices services;
        public BoardController(IServices _services)
        {
            services = _services;
        }

        public async Task<IActionResult> All()
        {
            var list = await services.GetAll();
            return View(list);
        }
    }
}
