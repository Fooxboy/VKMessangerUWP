using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Exceptions
{
    public class NoAccessGroupException : Exception
    {
        public NoAccessGroupException(string msg):base(msg) { }
    }
}
