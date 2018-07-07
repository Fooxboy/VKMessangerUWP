using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Exceptions
{
    public class CaptchaException : Exception
    {
        public CaptchaException(string msg) : base(msg) { }
    }
}
