using Fooxboy.VKMessagerUWP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Fooxboy.VKMessagerUWP
{
    /// <summary>
    /// Обеспечивает зависящее от конкретного приложения поведение, дополняющее класс Application по умолчанию.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Инициализирует одноэлементный объект приложения.  Это первая выполняемая строка разрабатываемого
        /// кода; поэтому она является логическим эквивалентом main() или WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Вызывается при обычном запуске приложения пользователем.  Будут использоваться другие точки входа,
        /// например, если приложение запускается для открытия конкретного файла.
        /// </summary>
        /// <param name="e">Сведения о запросе и обработке запуска.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Не повторяйте инициализацию приложения, если в окне уже имеется содержимое,
            // только обеспечьте активность окна
            if (rootFrame == null)
            {
                // Создание фрейма, который станет контекстом навигации, и переход к первой странице
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Загрузить состояние из ранее приостановленного приложения
                }

                CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

                if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
                {
                    var appView = ApplicationView.GetForCurrentView();
                    appView.TitleBar.ButtonBackgroundColor = Colors.Transparent;
                    appView.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                }

                // Размещение фрейма в текущем окне
                Window.Current.Content = rootFrame;
            }

            //создание папки с кэшем
            var itemFolder = await StaticContent.LocalFolder.TryGetItemAsync("Cache");
            if(itemFolder == null)
            {
                await StaticContent.LocalFolder.CreateFolderAsync("Cache");
            }

            //создание папки с базами данных
            var itemFolderDB = await StaticContent.LocalFolder.TryGetItemAsync("Databases");
            if (itemFolderDB == null)
            {
                await StaticContent.LocalFolder.CreateFolderAsync("Databases");
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    StaticContent.RootPageSet(rootFrame);
                    var item = await StaticContent.LocalFolder.TryGetItemAsync("Tokens.json");
                    if(item is null) rootFrame.Navigate(typeof(View.LoginView), e.Arguments);
                    else
                    {
                        try
                        {
                            var file = await StaticContent.LocalFolder.GetFileAsync("Tokens.json");
                            var jsonText = await FileIO.ReadTextAsync(file);
                            var accounts = JsonConvert.DeserializeObject<AccountsList>(jsonText);

                            if (accounts.Accounts[0].Token is null) rootFrame.Navigate(typeof(View.LoginView), e.Arguments);
                            else
                            {
                                var token = accounts.Accounts[0].Token;
                               // var vk = await StaticContent.GetVk(token);
                                rootFrame.Navigate(typeof(View.RootView), e.Arguments);
                            }
                        }
                        catch
                        {
                            rootFrame.Navigate(typeof(View.LoginView), e.Arguments);
                        }
                    }
                }
                // Обеспечение активности текущего окна
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Вызывается в случае сбоя навигации на определенную страницу
        /// </summary>
        /// <param name="sender">Фрейм, для которого произошел сбой навигации</param>
        /// <param name="e">Сведения о сбое навигации</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Вызывается при приостановке выполнения приложения.  Состояние приложения сохраняется
        /// без учета информации о том, будет ли оно завершено или возобновлено с неизменным
        /// содержимым памяти.
        /// </summary>
        /// <param name="sender">Источник запроса приостановки.</param>
        /// <param name="e">Сведения о запросе приостановки.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Сохранить состояние приложения и остановить все фоновые операции
            deferral.Complete();
        }
    }
}
