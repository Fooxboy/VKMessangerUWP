using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class ErrorLongPoll
    {
        public int failed { get; set; }
        public long ts { get; set; }
        public int min_version { get; set; }
        public int max_version { get; set; }
    }
}
