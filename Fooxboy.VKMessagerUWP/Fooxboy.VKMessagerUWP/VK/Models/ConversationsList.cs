using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class ConversationsList
    {
        public long count { get; set; }
        public long unread_count { get; set; }
        public List<ConversationsItem> items { get; set; }
        public List<User> profiles { get; set; }
        public List<Group> groups { get; set; }
    }

    public class ConversationsItem
    {
        public Conversation conversation { get; set; }
        public Message last_message { get; set; }
    }
}
