using Fooxboy.VKMessagerUWP.Model;
using Fooxboy.VKMessagerUWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fooxboy.VKMessagerUWP.View
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DialogsPageView : Page
    {
        public DialogsViewModel ViewModel { get; set; }

        public SearchViewModel Search { get; set; }


        public DialogsPageView()
        {
            this.InitializeComponent();

            ViewModel = DialogsViewModel.GetVM();
            Search = new SearchViewModel();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.IsLoadingPage = true;
            await ViewModel.GetDialogs();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.FindName("FriendsListView");
        }
    }
}
