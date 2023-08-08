using ASP.NET_Chat.Models.Chat;
using ASP.NET_Chat.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Chat.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> messages = new();

        [ActionName("Index")]
        public IActionResult Show()
        {
            if (messages.Count == 0)
            {
                return View(new ChatViewModel());
            }

            var chat = new ChatViewModel()
            {
                Messages = messages.Select(x => new MessageViewModel()
                {
                    Sender = x.Key,
                    Message = x.Value
                }).ToList()
            };

            return View(chat);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var message = chat.Message;

            messages.Add(new KeyValuePair<string, string>(message.Sender, message.Message));

            return RedirectToAction("Index");
        }
    }
}
