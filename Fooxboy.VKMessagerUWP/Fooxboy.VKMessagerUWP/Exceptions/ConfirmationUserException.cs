﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Exceptions
{
    public class ConfirmationUserException : Exception
    {
        public ConfirmationUserException(string msg) : base(msg) { }
    }
}
