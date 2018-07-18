using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class HistoryMessage
    {
        public long count { get; set; }
        public List<Message> items { get; set; }
        public List<Conversation> conversations { get; set; }
        public List<User> profiles { get; set; }
    }
}
