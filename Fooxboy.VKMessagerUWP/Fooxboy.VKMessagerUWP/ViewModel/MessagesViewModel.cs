﻿using Fooxboy.VKMessagerUWP.Model;
using Fooxboy.VKMessagerUWP.VK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class MessagesViewModel : BaseViewModel
    {

        private LoadingCollection<MessageElementModel> messages;
        public LoadingCollection<MessageElementModel> Messages
        {
            get => messages;
            set
            {
                if (value == messages) return;

                messages = value;
                Changed("Messages");
            }
        }

        private Visibility visibleListView = Visibility.Visible;
        public Visibility VisibleListView
        {
            get => visibleListView;
            set
            {
                if (value == visibleListView) return;

                visibleListView = value;
                Changed("VisibleListView");
            }
        }

        private bool isLoading = false;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (value == isLoading) return;

                isLoading = value;
                Changed("IsLoading");
            }
        }

        private long maxCount = -1;
        private PinnedMessage pinnedMessage;
        private long peerId = 0;

        public PinnedMessage PinnedMesssage
        {
            get => pinnedMessage;
            set
            {
                if (value == pinnedMessage) return;

                pinnedMessage = value;
                Changed("PinnedMessage");
            }
        }

        public async Task StartLoading(DialogsElementModel selectDialog)
        {
            Messages = new LoadingCollection<MessageElementModel>();
            Messages.OnMoreItemsRequested = GetMoreMessages;
            Messages.HasMoreItemsRequested = () =>
            {
                if (maxCount == 0) return false;
                else if (maxCount == -1) return true;
                else return Messages.Count < maxCount;
            };
            try
            {
                pinnedMessage = selectDialog.Conversation.conversation.chat_settings.pinned_message;
            }catch
            {

            }

            peerId = selectDialog.Conversation.conversation.peer.id;

        }

        private async Task<List<MessageElementModel>> GetMoreMessages(CancellationToken token, uint countDialog)
        {
            IsLoading = true;
            VisibleListView = Visibility.Collapsed;
            var history = await VK.Methods.Messages.History(offset: Messages.Count, peer_id: peerId, count: 50, fields: "photo_50");
            maxCount = history.count;
            List<MessageElementModel> list = new List<MessageElementModel>();
            foreach(var message in history.items)
            {
                User user;
                Message msg = message;
                Uri photo;

                user = history.profiles.Find(x => x.id == message.from_id);
                photo = await DownloaderImages.Dowload(user.photo_50, $"user_{user.id}_50.jpg");

                list.Add(new MessageElementModel()
                {
                    BodyUser = msg.text,
                    PhotoUser = photo,
                    Date = VK.Converts.ToDateString(msg.date),
                    NameUser = $"{user.first_name} {user.last_name}"
                });
            }
            IsLoading = false;
            VisibleListView = Visibility.Visible;
            var a = Messages;
            return list;
        }


        public static MessagesViewModel GetVM()
        {
            if(instanse == null)
            {
                instanse = new MessagesViewModel();
            }

            return instanse;
        }
        private static MessagesViewModel instanse;

        private MessagesViewModel() { }
    }
}
