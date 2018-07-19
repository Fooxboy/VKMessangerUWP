using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.LongPoll
{
    public class FriendOnlineModel
    {
        public long UserId { get; set; }
        public long Platform { get; set; }
        public long Time { get; set; }
    }
}
