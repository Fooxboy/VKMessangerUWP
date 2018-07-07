using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Market
    {
        public long  id { get; set; }
        public long owner_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public PriceMarket price { get; set; }
        public CategoryMarket category { get; set; }
        public string thumb_photo { get; set; }
        public long date { get; set; }
        public int availability { get; set; }

        public class PriceMarket
        {
            public int amount { get; set; }
            public string text { get; set; }
        }

        public class CategoryMarket
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public override string ToString()
        {
            return "Товар";
        }

        public string ToMore() => "Товара";
    }
}
