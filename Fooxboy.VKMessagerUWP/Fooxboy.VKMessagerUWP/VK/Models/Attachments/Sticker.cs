using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Sticker
    {
        public long product_id { get; set; }
        public long sticker_id { get; set; }
        public List<ImageSticker> images { get; set; }
        public List<ImageSticker> images_with_background { get; set; }

        public class ImageSticker
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public override string ToString()
        {
            return "Стикер";
        }
    }
}
