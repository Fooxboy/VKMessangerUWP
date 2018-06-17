
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace Fooxboy.VKMessagerUWP.Model
{
    public static class Auth
    {
       /* public async static Task AuthForLogin(string login, string password)
        {
            Model.AccountsList accounts;
            StorageFile file;
            var items = await StaticContent.LocalFolder.TryGetItemAsync("Accounts.json");
            if (items is null)
            {
                await StaticContent.LocalFolder.CreateFileAsync("Accounts.json");
                accounts = new AccountsList() { Accounts = new List<Account>() };
                file = await StaticContent.LocalFolder.GetFileAsync("Accounts.json");
            }
            else
            {
                file = await StaticContent.LocalFolder.GetFileAsync("Accounts.json");
                var json = await FileIO.ReadTextAsync(file);
                accounts = JsonConvert.DeserializeObject<AccountsList>(json);
            }

            var api = new VkApi();
            await api.AuthorizeAsync(new ApiAuthParams
            {
                ApplicationId = 6604325,
                Login = login,
                Password = password,
                Settings = Settings.All
            });

            var userId = api.UserId.Value;
            var user = await api.Users.GetAsync(new List<long> { userId }, ProfileFields.Photo400Orig);

            var account = new Account()
            {
                Token = api.Token,
                Id = userId,
                Name = user.FirstOrDefault().FirstName,
                Pic = user.FirstOrDefault().Photo400Orig.ToString(),
                PicIsUrl = true
            };

            accounts.Accounts.Add(account);
            var jsonAccounts = JsonConvert.SerializeObject(accounts);

            await FileIO.WriteTextAsync(file, jsonAccounts);

            ContentDialog contentDialog = new ContentDialog()
            {
                Title = "Полученные данные",
                Content = $"Token= {account.Token} ID = {account.Id} Name = {account.Name} Pic = {account.Pic}",
                PrimaryButtonText = "ОК",
                SecondaryButtonText = "Отмена"
            };

            ContentDialogResult result = await contentDialog.ShowAsync();
        }

        public static VkApi AuthForToken()
        {
            var api = new VkApi();

            api.Authorize(new ApiAuthParams
            {
                AccessToken = ""
            });

          
            return api;
        }*/
    }
}
