using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Document
    {
        public long id { get; set; }
        public long owner_id { get; set; }
        public string title { get; set; }
        public long size { get; set; }
        public string ext { get; set; }
        public string url { get; set; }
        public long date { get; set; }
        public int type { get; set; }
        public PreviewDoc preview { get; set; }

        public class PreviewDoc
        {
            public PhotoPreview photo { get; set; }
            public Graffiti graffiti { get; set; }
            public AudioMsg audio_msg { get; set; }

            public class PhotoPreview
            {
                public List<object> sizes { get; set; }
            }

            public class Graffiti
            {
                public string src { get; set; }
            }

            public class AudioMsg
            {
                public int duration { get; set; }
                public List<int> waveform { get; set; }
                public string link_ogg { get; set; }
                public string link_mp3 { get; set; }
            }
        }

        public override string ToString()
        {
            return "Документ";
        }

        public string ToMore() => "Документа";
    }
}
