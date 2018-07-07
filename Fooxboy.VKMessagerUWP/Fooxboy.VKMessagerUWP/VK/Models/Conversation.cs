using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class Conversation
    {
        public ConversationPeer peer { get; set; }
        public long in_read { get; set; }
        public long out_read { get; set; }
        public long unread_count { get; set; }
        public PushSettings push_settings { get; set; }
        public ConversationCanWrite can_write { get; set; }
        public ConversationChatSettings chat_settings { get; set; }
    }

    public class ConversationPeer
    {
        public long id { get; set; }
        public string type { get; set; }
        public long local_id { get; set; }
    }
}
