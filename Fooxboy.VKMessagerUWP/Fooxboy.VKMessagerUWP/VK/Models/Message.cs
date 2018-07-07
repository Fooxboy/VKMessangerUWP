using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class Message
    {
        public long id { get; set; }
        public long date { get; set; }
        public long peer_id { get; set; }
        public long from_id { get; set; }
        public string text { get; set; }
        public long random_id { get; set; }
        public List<Attach> attachments { get; set; }
        public bool important { get; set; }
        public Geo geo { get; set; }
        public string payload { get; set; }
        public List<Message> fwd_messages { get; set; }
        public ActionChat action { get; set; }
    }
}
