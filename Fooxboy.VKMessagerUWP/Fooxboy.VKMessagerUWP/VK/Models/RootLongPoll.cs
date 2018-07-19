using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class RootLongPoll
    {
        public long Ts { get; set; }
        public List<List<object>> Updates { get; set; }
    }
}
