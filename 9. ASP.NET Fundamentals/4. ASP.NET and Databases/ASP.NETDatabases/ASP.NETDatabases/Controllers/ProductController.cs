using ASP.NET.Services.Models;
using ASP.NET.Services.Services.Ìnterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETDatabases.Controllers
{
    public class ProductController : Controller
    {
        private readonly IPropductServices services;

        public ProductController(IPropductServices _services)
        {
            services = _services;
        }

        public async Task<IActionResult> Index()
        {
            var model = await services.GetProductsAsync();
            return View(model);
        }

        public IActionResult Add()
        {
            return View(new ProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel product)
        {
            await services.AddProductsAsync(product);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await services.GetCurrentProductAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductViewModel product)
        {
            await services.EditProductsAsync(id, product);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await services.DeleteProductsAsync(id);

            return RedirectToAction("Index");
        }
    }
}
