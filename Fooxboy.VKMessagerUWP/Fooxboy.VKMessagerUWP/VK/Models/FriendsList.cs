﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class FriendsList
    {
        public long count { get; set; }
        public List<User> items { get; set; }
    }
}
