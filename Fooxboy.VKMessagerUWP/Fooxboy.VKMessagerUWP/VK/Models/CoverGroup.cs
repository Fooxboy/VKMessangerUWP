using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class CoverGroup
    {
        public int enabled { get; set; }
        public List<CoverImageGroup> images { get; set; }

        public class CoverImageGroup
        {
            public string url { get; set; }
            public long width { get; set; }
            public long height { get; set; }
        }
    }
}
