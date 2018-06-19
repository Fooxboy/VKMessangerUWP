using Fooxboy.VKMessagerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class DialogsViewModel :BaseViewModel
    {

        private static DialogsViewModel dialogsViewModel = null;

        public static DialogsViewModel GetVM()
        {
            if (dialogsViewModel is null)
            {
                var vm = new DialogsViewModel();
                vm._titleText = "Диалоги";
                vm._isOpenDialogs = true;
                vm._isOpenFriend = false;
                vm._isOpenSettings = false;
                vm._isLoadingPage = false;
                vm._itemsDialogs = new ObservableCollection<DialogsElementModel>
                {
                    new DialogsElementModel()
                    {
                        Title="ИмяПаблика",
                        Body="Типа сообщение паблика",
                        Id = 1,
                        PhotoUrl = "ms-appx:///Images/PhotoUser.jpg"
                    }
                };

                vm._itemsMessages = new ObservableCollection<MessageElementModel>();

                for (int i = 0; i < 1000; i++)
                {
                    vm._itemsDialogs.Add(new DialogsElementModel()
                    {
                        Title = $"Петя Петров{i}",
                        Body = $"Сообщение нормер {i}",
                        Id = i,
                        Name = "Славик:",
                        PhotoUrl = "ms-appx:///Images/PhotoUser.jpg"
                    });
                }

                /*vm._selectItemDialog = new DialogsElementModel()
                {
                    Title = "Не выбрано",
                    Body = "Не выбрано",
                    Id = 0,
                    Name = "",
                    PhotoUrl = ""
                };*/
                vm._visibleDialogView = Visibility.Collapsed;
                vm._visibleNoSelectDialogView = Visibility.Visible;


                for (int i = 0; i < 1000; i++)
                {
                    bool byMe = (i % 2 == 0);
                    vm._itemsMessages.Add(new MessageElementModel
                    {
                        Body = "Привет, иди нахуй.",
                        MessageId = i,
                        UserFromId = i,
                        Time = "20:44",
                        ByMe = byMe
                    });

                    dialogsViewModel = vm;
                }  
            }

            return dialogsViewModel;
        }

        private DialogsViewModel() { }

        private Visibility _visibleDialogView;
        public Visibility VisibleDialogView
        {
            get => _visibleDialogView;
            set
            {
                if (value == _visibleDialogView) return;
                _visibleDialogView = value;
                Changed("VisibleDialogView");
            }
        }

        private ObservableCollection<MessageElementModel> _itemsMessages;
        public ObservableCollection<MessageElementModel> ItemsMessgages
        {
            get => _itemsMessages;
            set
            {
                if (value == _itemsMessages) return;
                _itemsMessages = value;
                Changed("ItemsMessgages");
            }
        }

        private Visibility _visibleNoSelectDialogView;
        public Visibility VisibleNoSelectDialogView
        {
            get => _visibleNoSelectDialogView;
            set
            {
                if (value == _visibleNoSelectDialogView) return;

                _visibleNoSelectDialogView = value;
                Changed("VisibleNoSelectDialogView");
            }
        }

        public void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenDialogPage();
        }

        public void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OpenDialogPage();
        }

        private void OpenDialogPage()
        {
            if(VisibleDialogView == Visibility.Collapsed)
            {
                VisibleDialogView = Visibility.Visible;
                VisibleNoSelectDialogView = Visibility.Collapsed;
            }   
        }


        private ObservableCollection<DialogsElementModel> _itemsDialogs;

        public ObservableCollection<DialogsElementModel> ItemsDialogs
        {
            get => _itemsDialogs;
            set
            {
                if (value == _itemsDialogs) return;

                _itemsDialogs = value;
                Changed("ItemsDialogs");
            }
        }

        private DialogsElementModel _selectItemDialog;
        public DialogsElementModel SelectItemDialog
        {
            get => _selectItemDialog;
            set
            {
                if (value == _selectItemDialog) return;

                _selectItemDialog = value;
                Changed("SelectItemDialog");
            }
        }

        private bool _isLoadingPage;
        public bool IsLoadingPage
        {
            get => _isLoadingPage;
            set
            {
                if (value == _isLoadingPage) return;

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
                if (value == _heightBarApp) return;

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
                if (value == _titleText) return;

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
                if (value == _isOpenDialogs) return;

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
                if (value == _isOpenFriend) return;

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
                if (value == _isOpenSettings) return;

                _isOpenSettings = value;
                Changed("IsOpenSettings");
            }
        }
    }
}
