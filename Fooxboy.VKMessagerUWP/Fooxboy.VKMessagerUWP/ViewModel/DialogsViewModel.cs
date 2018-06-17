using Fooxboy.VKMessagerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class DialogsViewModel :BaseViewModel
    {
        public DialogsViewModel()
        {
            _titleText = "Диалоги";
            _isOpenDialogs = true;
            _isOpenFriend = false;
            _isOpenSettings = false;
            _isLoadingPage = false;
            _items = new ObservableCollection<DialogsElementModel>
            {
                new DialogsElementModel()
                {
                    Title="ИмяПаблика",
                    Body="Типа сообщение паблика",
                    Id = 1,
                    PhotoUrl = "ms-appx:///Images/PhotoUser.jpg"
                }
            };

            for(int i=0; i< 1000; i++)
            {
                _items.Add(new DialogsElementModel()
                {
                    Title = $"Петя Петров{i}",
                    Body = $"Сообщение нормер {i}",
                    Id = i,
                    Name = "Славик:",
                    PhotoUrl = "ms-appx:///Images/PhotoUser.jpg"
                });
            }
        }

        private ObservableCollection<DialogsElementModel> _items;

        public ObservableCollection<DialogsElementModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                Changed("Items");
            }
        }

        private DialogsElementModel _selectItem;
        public DialogsElementModel SelectItem
        {
            get => _selectItem;
            set
            {
                _selectItem = value;
                Changed("SelectItem");
            }
        }

        private bool _isLoadingPage;
        public bool IsLoadingPage
        {
            get => _isLoadingPage;
            set
            {
                _isLoadingPage = value;
                Changed("IsLoadingPage");
            }
        }

        private Windows.UI.Xaml.GridLength _heightBarApp;
        public Windows.UI.Xaml.GridLength HeightBarApp
        {
            get => _heightBarApp;
            set
            {
                _heightBarApp = value;
                Changed("HeightBarApp");
                
            }
        }

        private string _titleText;
        public string TitleText
        {
            get => _titleText;
            set
            {
                _titleText = value;
                Changed("TitleText");
            }
        }

        private bool _isOpenDialogs;
        public bool IsOpenDialogs
        {
            get => _isOpenDialogs;
            set
            {
                _isOpenDialogs = value;
                Changed("IsOpenDialogs");
            }
        }


        private bool _isOpenFriend;
        public bool IsOpenFriend
        {
            get => _isOpenFriend;
            set
            {
                _isOpenFriend = value;
                Changed("IsOpenFriend");
            }
        }


        private bool _isOpenSettings;
        public bool IsOpenSettings
        {
            get => _isOpenSettings;
            set
            {
                _isOpenSettings = value;
                Changed("IsOpenSettings");
            }
        }
    }
}
