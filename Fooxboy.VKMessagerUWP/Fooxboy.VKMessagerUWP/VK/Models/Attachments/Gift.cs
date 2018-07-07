using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Gift
    {
        public long id { get; set; }
        public string thumb_256 { get; set; }
        public string thumb_96 { get; set; }
        public string thumb_48 { get; set; }

        public override string ToString()
        {
            return "Подарок";
        }

        public string ToMore => "Подарка";
    }
}
