using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Video
    {
        public long  id { get; set; }
        public long owner_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int duration { get; set; }
        public string photo_130 { get; set; }
        public string photo_320 { get; set; }
        public string photo_640 { get; set; }
        public string photo_800 { get; set; }
        public long date { get; set; }
        public long adding_date { get; set; }
        public int views { get; set; }
        public int comments { get; set; }
        public string player { get; set; }
        public string platform { get; set; }
        public int can_edit { get; set; }
        public int can_add { get; set; }
        public int is_private { get; set; }
        public string access_key { get; set; }
        public int processing { get; set; }
        public int live { get; set; }
        public int upcoming { get; set; }

        public override string ToString()
        {
            return "Видеозапись";
        }

        public string ToMore() => "Видеозаписей";
    }
}
