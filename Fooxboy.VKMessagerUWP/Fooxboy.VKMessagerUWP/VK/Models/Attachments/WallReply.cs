using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class WallReply
    {
        public long id { get; set; }
        public long from_id { get; set; }
        public long date { get; set; }
        public string text { get; set; }
        public long reply_to_user { get; set; }
        public long reply_to_comment { get; set; }
        public List<Attach> attachments { get; set; }

        public override string ToString()
        {
            return "Комментарий на стене";
        }
    }
}
