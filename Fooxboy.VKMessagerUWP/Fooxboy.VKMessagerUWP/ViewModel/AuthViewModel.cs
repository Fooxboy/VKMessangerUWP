using Fooxboy.VKMessagerUWP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class AuthViewModel : BaseViewModel
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        public string Login
        {
            get => _login;
            set
            {
                if (value == _login) return;
                _login = value;
                Changed("Login");
            }
        }

        private RelayCommand _AuthComamnd;
        public RelayCommand AuthCommand
        {
            get => _AuthComamnd = _AuthComamnd ?? new RelayCommand(StartAuth);
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                Changed("Password");
            }
        }

        private async void StartAuth()
        {
            //Проверяем существование файла с токенами.
            var item = await StaticContent.LocalFolder.TryGetItemAsync("Accounts.json");

         /*   ContentDialog contentDialog = new ContentDialog()
            {
                Title = "Полученные данные",
                Content = $"item is null = {item is null}",
                PrimaryButtonText = "ОК",
                SecondaryButtonText = "Отмена"
            };*/

            //ContentDialogResult result = await contentDialog.ShowAsync();
            //StorageFile file;
            //Model.AccountsList accounts;

            //var api = new VkApi();
            //await api.AuthorizeAsync(new ApiAuthParams
            //{
            //    ApplicationId = 6604325,
            //    Login = _login,
            //    Password = _password,
            //    Settings = Settings.All
            //});

            //if (item is null)
            //{
            //    //создание файла
            //    file = await StaticContent.LocalFolder.CreateFileAsync("Accounts.json");
            //    accounts = new Model.AccountsList();
            //}else
            //{
            //    file = await StaticContent.LocalFolder.GetFileAsync("Accounts.json");
            //    var json = await FileIO.ReadTextAsync(file);
            //    accounts = JsonConvert.DeserializeObject<AccountsList>(json);
            //}


        }
    }
}
