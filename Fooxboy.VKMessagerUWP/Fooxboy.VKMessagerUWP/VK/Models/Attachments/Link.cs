using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Link
    {
        public string url { get; set; }
        public string title { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public Photo photo { get; set; }
        public ProductLink product { get; set; }
        public ButtonLink button { get; set; }
        public string preview_page { get; set; }
        public string preview_url { get; set; }

        public class ProductLink
        {
            public PriceProduct price { get; set; }
            public class PriceProduct
            {
                public int amount { get; set; }
                public string text { get; set; }
            }
        }

        public class ButtonLink
        {
            public string title { get; set; }
            public ActionButton action { get; set; }

            public class ActionButton
            {
                public string type { get; set; }
                public string url { get; set; }
            }
        }

        public override string ToString()
        {
            return "Ссылка";
        }

        public string ToMore() => "Ссылки";
    }
}
