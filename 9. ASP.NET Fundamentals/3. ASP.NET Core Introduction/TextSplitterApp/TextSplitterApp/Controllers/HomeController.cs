using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Split(TextViewModel model)
        {
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Splitter(TextViewModel model)
        {
            var sb = new StringBuilder();

            foreach (var item in model.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray())
            {
                sb.AppendLine(item);
            }

            model.SplitText = sb.ToString().TrimEnd();
            return RedirectToAction("Split", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}