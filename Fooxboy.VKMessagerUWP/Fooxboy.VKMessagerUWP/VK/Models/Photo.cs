using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class Photo
    {
        public long id { get; set; }
        public long album_id { get; set; }
        public long owner_id { get; set; }
        public long user_id { get; set; }
        public string text { get; set; }
        public long date { get; set; }
        public List<object> sizes { get; set; }
        public string photo_75 { get; set; }
        public string photo_130 { get; set; }
        public string photo_604 { get; set; }
        public string photo_807 { get; set; }
        public string photo_1280 { get; set; }
        public string photo_2560 { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
