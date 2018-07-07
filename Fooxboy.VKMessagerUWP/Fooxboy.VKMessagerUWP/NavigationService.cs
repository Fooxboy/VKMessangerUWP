using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Fooxboy.VKMessagerUWP
{
    public class NavigationService
    {
        public Stack<Type> Pages = new Stack<Type>();
        public Frame RootFrame { get; set; }

        /// <summary>
        /// Навигация к какой-либо странице.
        /// </summary>
        /// <param name="page"> Страница</param>
        /// <param name="parametr">Параметр</param>
        public void GoTo(Type page, object parametr = null)
        {
            if (this.Pages.Count > 0)
            {
                if (this.Pages.Peek() == page) return;
            }
            this.Pages.Push(page);
            this.UpdateButton();
            this.RootFrame.Navigate(page, parametr);
        }

        /// <summary>
        /// Возврат на предыдущую страницу.
        /// </summary>
        public void Back()
        {
            
            if (this.RootFrame.CanGoBack)
                this.RootFrame.GoBack();
            this.Pages.Pop();
            this.UpdateButton();
        }

        /// <summary>
        /// Обновление кнопки
        /// </summary>
        void UpdateButton()
        {
            SystemNavigationManager.GetForCurrentView().
                AppViewBackButtonVisibility = RootFrame.CanGoBack ?
                 AppViewBackButtonVisibility.Visible :
                     AppViewBackButtonVisibility.Collapsed;
        }
    }
}
