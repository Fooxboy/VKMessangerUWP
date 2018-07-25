using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK
{
    public static class Request
    {
        public static async Task<string> GetAsync(string method, Dictionary<string, string> parameters)
        {
            Logger.Info("Старт обращения к серверу ВКонтакте....");
            string parametersString = string.Empty;
            foreach(var param in parameters)
            {
                if(param.Value == string.Empty || param.Value == "" || param.Value == "0")
                {

                }else
                {
                    parametersString += $"{param.Key}={param.Value}&";
                }
            }
            var token = await Token.Get();
            string url = $"https://api.vk.com/method/{method}?{parametersString}access_token={token}&v=5.80";
            string result = "";
            Logger.Info($"Запрос к серверу. Url: {url}");
            using(var client = new WebClient())
            {
                result = await client.DownloadStringTaskAsync(url);
            }
            Logger.Info("Данные получены.");
            return result;
        }
    }
}
