using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Fooxboy.VKMessagerUWP.VK.Models;

namespace Fooxboy.VKMessagerUWP.Model
{
    public class DialogsElementModel : ViewModel.BaseViewModel
    {
        public long Id { get; set; }
        public ConversationsItem Conversation { get; set; }
        private string photo_id = string.Empty;
        public string PhotoUrl
        {
            get => photo_id;
            set
            {
                if(value != photo_id)
                {
                    Changed("PhotoUrl");
                    photo_id = value;
                }        
            }
        }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Visibility VisibleUnread { get; set; }
        public string CountUnread { get; set; }
        public int WidthUnread { get; set; }
        public Visibility MuteNotifications { get; set; }
        public string Time { get; set; }
    }
}
