using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Exceptions
{
    public class NoAccessAudioException : Exception
    {
        public NoAccessAudioException(string msg):base(msg) { }
    }
}
