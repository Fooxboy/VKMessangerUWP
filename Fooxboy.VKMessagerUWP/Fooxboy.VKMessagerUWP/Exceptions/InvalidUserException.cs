using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string msg):base(msg) { }
    }
}
