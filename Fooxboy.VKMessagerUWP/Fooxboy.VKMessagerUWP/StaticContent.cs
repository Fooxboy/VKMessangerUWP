using Fooxboy.VKMessagerUWP.VK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace Fooxboy.VKMessagerUWP
{
    public static class StaticContent
    {
        public static StorageFolder LocalFolder = ApplicationData.Current.LocalFolder;

        public static void MessagesFrameSet(Frame frame)
        {
            var navig = new NavigationService()
            {
                RootFrame = frame
            };
            _messagesFrame = navig;
        }

        public async static Task<User> Me(string a = "") => await VK.Methods.Users.Me(a);


        private static NavigationService _messagesFrame;
        public static NavigationService MessagesFrame
        {
            get
            {
                if (_messagesFrame is null) throw new Exception("Не проинициаллизирован навигатор серсив");
                return _messagesFrame;
            }
        }

        public static void DialogsFrameSet(Frame frame)
        {
            var navig = new NavigationService()
            {
                RootFrame = frame
            };
            _dialogsFrame = navig;
        }
        private static NavigationService _dialogsFrame;
        public static NavigationService DialogsFrame
        {
            get
            {
                if (_dialogsFrame is null) throw new Exception("Не проинициаллизирован навигатор серсив");
                return _dialogsFrame;
            }
        }

        public static void RootPageSet(Frame frame)
        {
            var navig = new NavigationService()
            {
                RootFrame = frame
            };
            _rootPage = navig;
        }
        private static NavigationService _rootPage;
        public static NavigationService RootPage
        {
            get
            {
                if (_rootPage is null) throw new Exception("Не проинициаллизирован навигатор серсив");
                return _rootPage;
            }
        }
    }
}
