using Fooxboy.VKMessagerUWP.VK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Model
{
    public class MessageElementModel
    {
        public string NameUser { get; set; }
        public string BodyUser { get; set; }
        public Uri PhotoUser { get; set; }
        public string Date { get; set; }
    }
}
