using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.LongPoll
{
    public class EditMsgModel
    {
        public long MessageId { get; set; }
        public long Mask { get; set; }
        public long PeerId { get; set; }
        public long Time { get; set; }
        public string NewText { get; set; }
        public Attachments Attachments { get; set; }
    }
}
