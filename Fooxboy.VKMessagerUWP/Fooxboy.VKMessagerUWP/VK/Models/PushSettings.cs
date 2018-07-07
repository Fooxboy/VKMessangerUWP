using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class PushSettings
    {
        public long disabled_until { get; set; }
        public bool disabled_forever { get; set; }
        public bool no_sound { get; set; }
    }
}
