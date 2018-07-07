using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models
{
    public class CropPhotoUser
    {
        public Photo photo { get; set; }
        public Crop crop { get; set; }
        public Crop rest { get; set; }

        public class Crop
        {
            public object x { get; set; }
            public object y { get; set; }
            public object x2 { get; set; }
            public object y2 { get; set; }
        }
    }
}
