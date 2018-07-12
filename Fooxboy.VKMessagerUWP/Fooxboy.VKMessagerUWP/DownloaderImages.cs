using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Fooxboy.VKMessagerUWP
{
    public static class DownloaderImages
    {
        private static void ToCache(string url, string name, StorageFolder folderImage)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, $"{folderImage.Path}/{name}");
            }
        }


        public async static Task<Uri> Dowload(string url, string name)
        {
            return new Uri(url);
        }
    }
}
