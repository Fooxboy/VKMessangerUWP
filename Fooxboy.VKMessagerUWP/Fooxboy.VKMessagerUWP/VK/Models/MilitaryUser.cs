using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class MilitaryUser
    {
        public string unit { get; set; }
        public long unit_id { get; set; }
        public long country_id { get; set; }
        public long from { get; set; }
        public long until { get; set; }
    }
}
