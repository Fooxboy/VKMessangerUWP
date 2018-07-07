using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Exceptions
{
    public class NoAuthException : Exception
    {
        public NoAuthException(string msg) : base(msg)
        {

        }
    }
}
