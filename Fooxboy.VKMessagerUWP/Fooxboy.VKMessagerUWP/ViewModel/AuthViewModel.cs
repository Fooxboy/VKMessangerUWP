using Fooxboy.VKMessagerUWP.Controls;
using Fooxboy.VKMessagerUWP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.ApplicationModel.Core;
using Windows.Security.Authentication.Web;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class AuthViewModel : BaseViewModel
    {
        private bool _isStartLoading = false;
        public bool IsStartLoading
        {
            get => _isStartLoading;
            set
            {
                if (value == _isStartLoading) return;
                _isStartLoading = value;
                Changed("IsStartLoading");
            }
        }

        private Visibility _visibilityLoginGrid = Visibility.Visible;
        public Visibility VisibilityLoginGrid
        {
            get => _visibilityLoginGrid;
            set
            {
                if (value == _visibilityLoginGrid) return;
                _visibilityLoginGrid = value;
                Changed("VisibilityLoginGrid");
            }
        }

        private Visibility _visibilityLoadingGrid = Visibility.Collapsed;
        public Visibility VisibilityLoadingGrid
        {
            get => _visibilityLoadingGrid;
            set
            {
                if (value == _visibilityLoadingGrid) return;
                _visibilityLoadingGrid = value;
                Changed("VisibilityLoadingGrid");
            }
        }

        private RelayCommand _AuthComamnd;
        public RelayCommand AuthCommand
        {
            get => _AuthComamnd = _AuthComamnd ?? new RelayCommand( async()=> await StartAuth());
        }

        private async Task StartAuth()
        {
            Logger.Info("Инициализация начала авторизации...");
            VisibilityLoadingGrid = Visibility.Visible;
            IsStartLoading = true;
            string startUrl = "https://oauth.vk.com/authorize?client_id=6604325&display=popup&redirect_uri=https://oauth.vk.com/blank.html&scope=friends,photos,messages,offline,docs&response_type=token&v=5.80&state=123456";
            string endUrl = "https://oauth.vk.com/blank.html";
            var startURI = new Uri(startUrl);
            string Token = string.Empty;
            var endURI = new Uri(endUrl);
            Logger.Info("Начато получение токена...");

            try
            {
                var result = await WebAuthenticationBroker
                                        .AuthenticateAsync(
                                        WebAuthenticationOptions.None,
                                        startURI,
                                        endURI);

                switch(result.ResponseStatus)
                {
                    case WebAuthenticationStatus.Success:
                        var responseString = result.ResponseData;
                        char[] separators = { '=', '&' };
                        string[] responseContent = responseString.Split(separators);
                        string accessToken = responseContent[1];
                        long userId = Int64.Parse(responseContent[5]);
                        Token = accessToken;
                        Logger.Info($"Токен: {Token}");
                        break;
                    case WebAuthenticationStatus.ErrorHttp:
                        var message = new Windows.UI.Popups.MessageDialog("Проверте Ваше подключение к сети.", "Нет доступа к интернету");
                        await message.ShowAsync();
                        VisibilityLoadingGrid = Visibility.Collapsed;
                        IsStartLoading = false;
                        Logger.Error("Невозможно загрузить страницу авторизации. Ошибка сети");
                        return;
                    case WebAuthenticationStatus.UserCancel:
                        Logger.Error("Пользователь отменил авторизацию");
                        VisibilityLoadingGrid = Visibility.Collapsed;
                        IsStartLoading = false;
                        return;
                }
            }catch(Exception e)
            {
                var message = new Windows.UI.Popups.MessageDialog(e.ToString(), "Необработанное исключение");
                await message.ShowAsync();
                Logger.Error("Необработанное исключение при авторизации", e);
                VisibilityLoadingGrid = Visibility.Collapsed;
                IsStartLoading = false;
                return;
            }

            //Проверяем существование файла с токенами.
            var item = await StaticContent.LocalFolder.TryGetItemAsync("Tokens.json");

            StorageFile file;
            AccountsList accounts;

            if (item is null)
            {
                Logger.Info("Сохранение токена...");
                //создание файла
                file = await StaticContent.LocalFolder.CreateFileAsync("Tokens.json");
                accounts = new AccountsList();
                accounts.Accounts = new List<Account>();
            }
            else
            {
                //получение файла и аккаунты.
                file = await StaticContent.LocalFolder.GetFileAsync("Tokens.json");
                var jsonText = await FileIO.ReadTextAsync(file);
                accounts = JsonConvert.DeserializeObject<AccountsList>(jsonText);
            }

            //добавление аккаунта
            var acc = new Account()
            {
                Token = Token,
                Id = 0,
                Name = "NO NAME",
                Pic = "",
                PicIsUrl = true
            };
            accounts.Accounts.Add(acc);

            //сохрание файлов..
            var jsonFiles = JsonConvert.SerializeObject(accounts);
            await FileIO.WriteTextAsync(file, jsonFiles);  

            var currentUser = await VK.Methods.Users.Me(fields: "photo_100");

            //добавление аккаунта
            accounts.Accounts.Remove(acc);
            jsonFiles = string.Empty;
            accounts.Accounts.Add(new Account()
            {
                Token = Token,
                Id = currentUser.id,
                Name = $"{currentUser.first_name} {currentUser.last_name}",
                Pic = currentUser.photo_100,
                PicIsUrl = true
            });

            //сохрание файлов..
            jsonFiles = JsonConvert.SerializeObject(accounts);
            await FileIO.WriteTextAsync(file, jsonFiles);
            Logger.Info("Конец авторизации: Успешно");
            StaticContent.RootPage.GoTo(typeof(View.RootView));
        }
    }
}
