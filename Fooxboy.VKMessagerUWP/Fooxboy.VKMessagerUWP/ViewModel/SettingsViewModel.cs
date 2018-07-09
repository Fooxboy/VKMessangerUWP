using Fooxboy.VKMessagerUWP.Model;
using Fooxboy.VKMessagerUWP.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class SettingsViewModel: BaseViewModel
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (value == _isLoading) return;

                if (value) VisibForYouText = Visibility.Collapsed;
                else VisibForYouText = Visibility.Visible;
                _isLoading = value;
                Changed("IsLoading");
            }
        }

        private Visibility _visibForYouText;
        public Visibility VisibForYouText
        {
            get => _visibForYouText;
            set
            {
                if (value == _visibForYouText) return;

                _visibForYouText = value;
                Changed("VisibForYouText");
            }
        }

        private SettingsDeleteCacheItem _itemDeleteCache;
        public SettingsDeleteCacheItem ItemDeleteCache
        {
            get => _itemDeleteCache;
            set
            {
                if (value == _itemDeleteCache) return;

                _itemDeleteCache = value;
                Changed("ItemDeleteCache");
            }
        }

        private string _photo = "ms-appx:///Images/PhotoUser.jpg";
        public string Photo
        {
            get => _photo;
            set
            {
                if (value == _photo) return;

                _photo = value;
                Changed("Photo");
            }
        }

        private string _sizeCachePhoto;
        public string SizeCachePhoto
        {
            get => _sizeCachePhoto;
            set
            {
                if (value == _sizeCachePhoto) return;

                _sizeCachePhoto = value;
                Changed("SizeCachePhoto");
            }
        }

        private ObservableCollection<SettingsDeleteCacheItem> _itemsDelete;
        public ObservableCollection<SettingsDeleteCacheItem> ItemsDelete
        {
            get => _itemsDelete;
            set
            {
                if (value == _itemsDelete) return;

                _itemsDelete = value;
                Changed("ItemsDelete");
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;

                _name = value;
                Changed("Name");
            }
        }

        public async Task ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            IsLoading = true;
            var user = await VK.Methods.Users.Me(fields: "photo_100");
            Photo = "ms-appx:///Images/PhotoUser.jpg";
            Name = $"{user.first_name} {user.last_name}";
            Photo = await DownloaderImages.Dowload(user.photo_100, $"user_{user.id}_100.jpg");
            SizeCachePhoto = "вычисление....";
            IsLoading = false;
            ulong size = 0;
            string sizeType = "";

            var cache = (StorageFolder)await StaticContent.LocalFolder.TryGetItemAsync("Cache");
            var item = await cache.TryGetItemAsync("Images");
            if (item != null)
            {
                var folderImage = (StorageFolder)item;
                var files = await folderImage.GetItemsAsync();
                foreach (StorageFile file in files)
                {
                    var prop = await file.GetBasicPropertiesAsync();
                    size += prop.Size;
                }
            }

            if (size > 1024)
            {
                size = size / 1024;
                sizeType = "КБ";
                if (size > 1024)
                {
                    size = size / 1024;
                    sizeType = "МБ";

                    if (size > 1024)
                    {
                        size = size / 1024;
                        sizeType = "ГБ";
                    }
                }
            } else
            {
                sizeType = "Байт";
            }

            SizeCachePhoto = $"{size} {sizeType}";
            ItemsDelete = new ObservableCollection<SettingsDeleteCacheItem>();

            ItemsDelete.Add(new SettingsDeleteCacheItem()
            {
                Path = "Images",
                Size = SizeCachePhoto,
                Title = "Изображения"
            });
        }


        private RelayCommand _deleteCacheCommand;
        public RelayCommand DeleteCacheCommand
        {
            get => _deleteCacheCommand = _deleteCacheCommand ?? new RelayCommand(async () => await DeleteCache());
        }


        public async Task DeleteCache()
        {
            if(ItemDeleteCache != null)
            {

                MessageDialog dialogA = new MessageDialog("Удаление кэша началось в фоновом режиме.");
                dialogA.Title = "Удаление кэша";
                await dialogA.ShowAsync();

                var cache = (StorageFolder)await StaticContent.LocalFolder.TryGetItemAsync("Cache");
                var itemDirectory = await cache.TryGetItemAsync(ItemDeleteCache.Path);
                if (itemDirectory != null)
                {


                    var directory = (StorageFolder)itemDirectory;
                    var files = await directory.GetFilesAsync();

                    foreach(var file in files)
                    {
                        try
                        {
                            await file.DeleteAsync();
                        }catch { }
                    }
                }
            }

            MessageDialog dialog = new MessageDialog("Кэш успешно очищен!");
            dialog.Title = "Удаление кэша";
            await dialog.ShowAsync();

        }


        private RelayCommand _unLoginCommand;
        public RelayCommand UnLoginCommand
        {
            get => _unLoginCommand = _unLoginCommand ?? new RelayCommand(async () => await UnLogin());
        }

        private async Task UnLogin()
        {
            IsLoading = true;
            Name = "Выходим из аккаунта...";
            var item = (StorageFile) await StaticContent.LocalFolder.TryGetItemAsync("Tokens.json");
            await item.DeleteAsync();
            StaticContent.RootPage.GoTo(typeof(LoginView));
        }
    }
}
