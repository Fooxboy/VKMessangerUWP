using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.LongPoll
{
    public class NotificationSettingsChangedModel
    {
        public long PeerId { get; set; }
        public long Second { get; set; }
        public long DisabledUntil { get; set; }
    }
}
