using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Wall
    {
        public long id { get; set; }
        public long owner_id { get; set; }
        public long from_id { get; set; }
        public long to_id { get; set; }
        public long created_by { get; set; }
        public long date { get; set; }
        public string text { get; set; }
        public long reply_owner_id { get; set; }
        public long reply_post_id { get; set; }
        public int friends_only { get; set; }
        public object comments { get; set; }
        public object likes { get; set; }
        public object reposts { get; set; }
        public object views { get; set; }
        public string post_type { get; set; }
        public object post_source { get; set; }
        public List<Attach> attachments { get; set; }
        public Geo geo { get; set; }
        public long signer_id { get; set; }
        public List<Wall> copy_history { get; set; }
        public int can_pin { get; set; }
        public int can_delete { get; set; }
        public int can_edit { get; set; }
        public int is_pinned { get; set; }
        public int marked_as_ads { get; set; }

        public override string ToString()
        {
            return "Запись на стене";
        }
    }
}
