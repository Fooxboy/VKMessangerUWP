using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class Error
    {
        public ErrorItem error { get; set; }
    }

    public class ErrorItem
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public List<RequestParam> request_params { get; set; }

        public class RequestParam
        {
            public string key { get; set; }
            public string value { get; set; }
        }
    }
}
