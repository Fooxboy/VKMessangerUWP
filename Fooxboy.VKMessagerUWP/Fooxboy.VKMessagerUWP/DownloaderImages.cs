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
        public async static Task<string> Dowload(string url, string name)
        {
            if (url is null) throw new Exception("Картинка - нулл");
            var item = await StaticContent.LocalFolder.TryGetItemAsync("cacheImage");
            StorageFolder folderImage;
            if (item is null)
            {
                folderImage = await StaticContent.LocalFolder.CreateFolderAsync("cacheImage");
            }
            else
            {
                folderImage = (StorageFolder)item;
            }

            var itemFile = await folderImage.TryGetItemAsync(name);
            StorageFile imageFile;
            if (itemFile is null)
            {
                imageFile = await folderImage.CreateFileAsync(name);

                using (var client = new WebClient())
                {
                   await client.DownloadFileTaskAsync(url, $"{folderImage.Path}/{name}"); 
                }
            }
            else
            {
                imageFile = (StorageFile)itemFile;
            }
            return $"ms-appdata:///local/cacheImage/{name}";
        }
    }
}
