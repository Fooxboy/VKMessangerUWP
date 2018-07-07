using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class Geo
    {
        public string type { get; set; }
        public string coordinates { get; set; }
        public GeoPlace place { get; set; } 
    }

    public class GeoPlace
    {
        public long  id { get; set; }
        public string title { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public long created { get; set; }
        public string icon { get; set; }
        public string country { get; set; }
        public string city { get; set; }
    }
}
