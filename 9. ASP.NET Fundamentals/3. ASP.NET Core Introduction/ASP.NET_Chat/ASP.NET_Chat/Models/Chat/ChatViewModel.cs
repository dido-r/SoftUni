using ASP.NET_Chat.Models.Message;

namespace ASP.NET_Chat.Models.Chat
{
    public class ChatViewModel
    {
        public MessageViewModel Message { get; set; }

        public List<MessageViewModel> Messages { get; set; }
    }
}
