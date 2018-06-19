using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Model
{
    public class MessageElementModel
    {
        public long MessageId { get; set; }
        public long UserFromId { get; set; }
        public string UrlPhoto { get; set; }
        public string Body { get; set; }
        public string Time { get; set; }
        public bool ByMe { get; set; }
    }
}
