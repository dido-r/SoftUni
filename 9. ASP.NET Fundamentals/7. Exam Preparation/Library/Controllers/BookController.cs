using Library.Services.Contracts;
using Library.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private IServices service;
        public BookController(IServices provider)
        {
            service = provider;
        }

        public async Task<IActionResult> All()
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return NotFound();
            }

            var list = await service.GetAllBooks();
            return View(list);
        }

        public async Task<IActionResult> Add()
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return NotFound();
            }

            var model = new BookFormModel()
            {
                Categories = await service.GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Add");
            }

            await service.CreateBook(model);

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var userId = GetUserId();
            await service.AddToCollection(id, userId);

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = GetUserId();
            await service.RemoveFromCollection(id, userId);

            return RedirectToAction("Mine");
        }

        public async Task<IActionResult> Mine()
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return NotFound();
            }

            var books = await service.GetMineBooks(userId);

            return View(books);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
