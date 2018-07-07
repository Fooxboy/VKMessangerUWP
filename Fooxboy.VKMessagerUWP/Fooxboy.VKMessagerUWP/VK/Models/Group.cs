using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class Group
    {
        public long id { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public int is_closed { get; set; }
        public string deactivated { get; set; }
        public int is_admin { get; set; }
        public int admin_level { get; set; }
        public int is_member { get; set; }
        public long invited_by { get; set; }
        public string type { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public string photo_200 { get; set; }
        public string activity { get; set; }
        public int age_limits { get; set; }
        public BanInfoGroup ban_info { get; set; }
        public int can_create_topic { get; set; }
        public int can_message { get; set; }
        public int can_post { get; set; }
        public int can_see_all_posts { get; set; }
        public int can_upload_doc { get; set; }
        public int can_upload_video { get; set; }
        public CityUser city { get; set; }
        public ContactsGroup contacts { get; set; }
        public object counters { get; set; }
        public CountryUser country { get; set; }
        public CoverGroup cover { get; set; }
        public CropPhotoUser crop_photo { get; set; }
        public string description { get; set; }
        public long fixed_post { get; set; }
        public int has_photo { get; set; }
        public int is_favorite { get; set; }
        public int is_hidden_from_feed { get; set; }
        public int is_messages_blocked { get; set; }
        public List<object> links { get; set; }
        public long main_album_id { get; set; }
        public int main_section { get; set; }
        public object market { get; set; }


    }
}
