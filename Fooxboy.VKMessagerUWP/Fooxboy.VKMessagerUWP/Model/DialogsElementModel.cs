using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Model
{
    public class DialogsElementModel
    {
        public long Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
