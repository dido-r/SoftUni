using ForumApp.Services.Interface;
using ForumApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private IPostServices service;

        public PostController(IPostServices _service)
        {
            service = _service;
        }
        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllPosts();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new PostViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            await service.CreatePost(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await service.GetCurrentPost(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostViewModel model)
        {
            await service.EditCurrentPost(id, model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeletePost(id);
            return RedirectToAction("Index");
        }
    }
}
