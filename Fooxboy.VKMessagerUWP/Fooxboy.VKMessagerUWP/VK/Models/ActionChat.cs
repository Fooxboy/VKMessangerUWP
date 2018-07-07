using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class ActionChat
    {
        public string type { get; set; }
        public long member_id { get; set; }
        public string text { get; set; }
        public string email { get; set; }
        public ConversationChatSettingsPhoto photo { get; set; }
    }
}
