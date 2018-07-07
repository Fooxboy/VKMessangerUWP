using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class CareerUser
    {
        public long group_id { get; set; }
        public string company { get; set; }
        public long country_id { get; set; }
        public long city_id { get; set; }
        public string city_name { get; set; }
        public int from { get; set; }
        public int until { get; set; }
        public string position { get; set; }
    }
}
