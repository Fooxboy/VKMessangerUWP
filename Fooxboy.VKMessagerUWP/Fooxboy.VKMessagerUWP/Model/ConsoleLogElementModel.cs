using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using static Fooxboy.VKMessagerUWP.Logger;

namespace Fooxboy.VKMessagerUWP.Model
{
    public class ConsoleLogElementModel
    {
        public string Text { get; set; }
        public TypeLog Type { get; set; }
        public Color Color { get; set; }
        public DateTime Time { get; set; }
    }

    public enum TypeLog
    {
        Info = 1,
        Waring = 2,
        Error = 3,
        Json = 4
    }
}
