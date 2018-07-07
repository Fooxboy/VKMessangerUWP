using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class ConversationChatSettings
    {
        public long members_count { get; set; }
        public string title { get; set; }
        public PinnedMessage pinned_message { get; set; }
        public string state { get; set; }
        public ConversationChatSettingsPhoto photo { get; set; }
        public List<long> active_ids { get; set; }
    }


    public class ConversationChatSettingsPhoto
    {
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public string photo_200 { get; set; }
    }
}
