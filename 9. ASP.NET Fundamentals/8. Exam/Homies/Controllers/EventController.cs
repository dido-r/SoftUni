using Homies.Services.Contracts;
using Homies.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private IService service;

        public EventController(IService data)
        {
            service = data;
        }

        public async Task<IActionResult> All()
        {
            if (User.Identity.Name == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var allEvents = await service.GetAllEvents();
            return View(allEvents);
        }

        public async Task<IActionResult> Add()
        {
            if (User.Identity.Name == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new EventFormModel
            {
                Types = await service.GetAllTypes()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Add");
            }

            var userId = GetUserId();
            await service.AddEvent(model, userId);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (User.Identity.Name == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await service.GetEventById(id);

            model.Types = await service.GetAllTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventEditModel model, int id)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Edit");
            }

            await service.EditEvent(model, id);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (User.Identity.Name == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await service.GetDetails(id);

            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            if (User.Identity.Name == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var userId = GetUserId();
            var myEvents = await service.GetJoinedEvents(userId);

            return View(myEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("All");
            }

            var userId = GetUserId();
            await service.JoinEvent(id, userId);

            return RedirectToAction("Joined");
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Joined");
            }

            var userId = GetUserId();
            await service.LeaveEvent(id, userId);

            return RedirectToAction("All");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
