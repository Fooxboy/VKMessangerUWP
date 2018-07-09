using Fooxboy.VKMessagerUWP.Exceptions;
using Fooxboy.VKMessagerUWP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Fooxboy.VKMessagerUWP.VK
{
    public static class Token
    {
        private static string _token = null;

        public async static Task<string> Get()
        {
            if(_token == null)
            {
                var item = await StaticContent.LocalFolder.TryGetItemAsync("Tokens.json");
                if (item is null) throw new NoTokenFoundException("Не найден файл Tokens.json");
                else
                {
                    var file = await StaticContent.LocalFolder.GetFileAsync("Tokens.json");
                    var jsonText = await FileIO.ReadTextAsync(file);
                    var accounts = JsonConvert.DeserializeObject<AccountsList>(jsonText);
                    if (accounts.Accounts[0].Token is null) throw new NoTokenFoundException("Не найден токен в файле");
                    else
                    {
                        var token = accounts.Accounts[0].Token;
                        _token = token;
                        return token;
                    }
                }
            }else
            {
                return _token;
            }
        }
    }
}
