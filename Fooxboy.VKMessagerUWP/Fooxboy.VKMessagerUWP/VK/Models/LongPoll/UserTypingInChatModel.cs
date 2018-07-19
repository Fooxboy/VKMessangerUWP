using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.LongPoll
{
    public class UserTypingInChatModel
    {
        public long UserId { get; set; }
        public long ChatId { get; set; }
    }
}
