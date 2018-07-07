using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class User
    {
        public long id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string deactivated { get; set; }
        public string about { get; set; }
        public string activities { get; set; }
        public string bdate { get; set; }
        public long blacklisted { get; set; }
        public long blacklisted_by_me { get; set; }
        public string books { get; set; }
        public long can_post { get; set; }
        public long online_mobile { get; set; }
        public long can_see_all_posts { get; set; }
        public long can_see_audio { get; set; }
        public long can_send_friend_request { get; set; }
        public long can_write_private_message { get; set; }
        public CareerUser career { get; set; }
        public CityUser city { get; set; }
        public long common_count { get; set; }
        public string connections { get; set; }
        public ContactsUser contacts { get; set; }
        public CountersUser counters { get; set; }
        public CountryUser country { get; set; }
        public CropPhotoUser crop_photo { get; set; }
        public string domain { get; set; }
        public EducationUser education { get; set; }
        public object exports { get; set; }
        public long followers_count { get; set; }
        public long friend_status { get; set; }
        public string games { get; set; }
        public long has_mobile { get; set; }
        public long has_photo { get; set; }
        public string home_town { get; set; }
        public string interests { get; set; }
        public long is_favorite { get; set; }
        public long is_friend { get; set; }
        public long is_hidden_from_feed { get; set; }
        public LastSeenUser last_seen { get; set; }
        public List<long?> lists { get; set; }
        public string maiden_name { get; set; }
        public MilitaryUser military { get; set; }
        public string movies { get; set; }
        public string music { get; set; }
        public string nickname { get; set; }
        public OccupationUser occupation { get; set; }
        public long online { get; set; }
        public PersonalUser personal { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public string photo_200_orig { get; set; }
        public string photo_200 { get; set; }
        public string photo_400_orig { get; set; }
        public string photo_id { get; set; }
        public string photo_max { get; set; }
        public string photo_max_orig { get; set; }
        public string quotes { get; set; }
        public List<RelativeUser> relatives { get; set; }
        public long relation { get; set; }
        public List<object> schools { get; set; }
        public string screen_name { get; set; }
        public long sex { get; set; }
        public long site { get; set; }
        public string status { get; set; }
        public long timezone { get; set; }
        public long trending { get; set; }
        public string tv { get; set; }
        public List<object> universities { get; set; }
        public long verified { get; set; }
        public string wall_default { get; set; }
    }
}
