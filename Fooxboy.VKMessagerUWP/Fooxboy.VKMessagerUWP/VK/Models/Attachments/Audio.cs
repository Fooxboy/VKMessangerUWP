using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Audio
    {
        public long id { get; set; }
        public long owner_id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public long duration { get; set; }
        public string url { get; set; }
        public long lyrics_id { get; set; }
        public long album_id { get; set; }
        public long genre_id { get; set; }
        public long date { get; set; }
        public long no_search { get; set; }
        public long is_hq { get; set; }

        public override string ToString()
        {
            return "Аудио";
        }

        public string ToMore() => "Аудио";
    }
}
