using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class PinnedMessage
    {
        public long id { get; set; }
        public long date { get; set; }
        public long from_id { get; set; }
        public string text { get; set; }
        public List<Attach> attachments { get; set; }
        public Geo geo { get; set; }
        public List<object> fwd_messages { get; set; }
    }
}
