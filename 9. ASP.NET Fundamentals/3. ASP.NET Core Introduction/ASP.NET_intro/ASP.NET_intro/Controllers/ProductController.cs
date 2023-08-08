using ASP.NET_intro.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ASP.NET_intro.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> list = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            }
        };
        [ActionName("My-Products")]
        public IActionResult All(string key)
        {
            if (key != null)
            {
                var products = list.Where(x => x.Name.ToLower() == key.ToLower());
                return View(products);
            }

            return View(list);
        }

        public IActionResult AllAsJson()
        {
            var optionts = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            return Json(list, optionts);
        }

        public IActionResult AllAsText()
        {
            var text = new StringBuilder();

            foreach (var item in list)
            {
                text.AppendLine($"Product {item.Id}: {item.Name} = {item.Price} lv.");
            }

            return Content(text.ToString());
        }

        public IActionResult AllAsTextFile()
        {
            var text = new StringBuilder();

            foreach (var item in list)
            {
                text.AppendLine($"Product {item.Id}: {item.Name} = {item.Price} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
            return File(Encoding.UTF8.GetBytes(text.ToString().TrimEnd()), "text/plain");
        }

        public IActionResult ById(int id)
        {
            var product = list.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }
    }
}
