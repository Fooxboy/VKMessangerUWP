using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class MarketAlbum
    {
        public long id { get; set; }
        public long owner_id { get; set; }
        public string title { get; set; }
        public Photo photo { get; set; }
        public int count { get; set; }
        public long updated_time { get; set; }

        public override string ToString()
        {
            return "Подборка товаров";
        }

        public string ToMore() => "Подборки товаров";
    }
}
