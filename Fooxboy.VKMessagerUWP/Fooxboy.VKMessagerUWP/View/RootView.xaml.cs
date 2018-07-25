using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
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
    public sealed partial class RootView : Page
    {
        public RootView()
        {
            this.InitializeComponent();
            Logger.Info("Создание split фрейма");
            StaticContent.DialogsFrameSet(FrameDialogs);
            StaticContent.MessagesFrameSet(FrameMessages);
            FrameMessages.Navigate(typeof(DialogView));
            FrameDialogs.Navigate(typeof(DialogsPageView));
            Logger.Info("Инициализация страниц DialogView и DialogView");

        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            

            base.OnNavigatedTo(e);
        }
    }
}
