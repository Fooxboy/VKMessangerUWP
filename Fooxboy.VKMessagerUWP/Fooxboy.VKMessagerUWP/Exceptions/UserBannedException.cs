using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Exceptions
{
    public class UserBannedException : Exception
    {
        public UserBannedException(string msg): base(msg) { }
    }
}
