using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class LongPollServer
    {
        public string key { get; set; }
        public long ts { get; set; }
        public string server { get; set; }
        public long pts { get; set; }
    }
}
