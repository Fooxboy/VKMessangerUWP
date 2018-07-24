using Fooxboy.VKMessagerUWP.VK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Fooxboy.VKMessagerUWP.Model
{
    public class FriendItem
    {
        public Uri PhotoUrl { get; set; }
        public string Name { get; set; }
        public Visibility Online { get; set; }
        public string Body { get; set; }
        public User Friend { get; set; }

    }
}
