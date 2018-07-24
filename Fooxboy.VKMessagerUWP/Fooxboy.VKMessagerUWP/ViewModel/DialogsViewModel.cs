using Fooxboy.VKMessagerUWP.Controls;
using Fooxboy.VKMessagerUWP.Model;
using Fooxboy.VKMessagerUWP.VK;
using Fooxboy.VKMessagerUWP.VK.Models;
using Fooxboy.VKMessagerUWP.VK.Models.Attachments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class DialogsViewModel :BaseViewModel
    {
        LongPollService longPollService;

        private DialogsViewModel()
        {
           _titleText = "Диалоги";
           _isOpenDialogs = true;
            var longpollservice = new LongPollService();
            longPollService = longpollservice;
        }

        private static DialogsViewModel Model;
        public static DialogsViewModel GetVM()
        {
            if (Model == null) Model = new DialogsViewModel();

            return Model;
        }

        private Visibility _visibleListView;
        public Visibility VisibleListView
        {
            get => _visibleListView;
            set
            {
                if (value == _visibleListView) return;

                _visibleListView = value;
                Changed("VisibleListView");
            }
        }

        //private FriendsViewModel Friends = FriendsViewModel.GetVM();

        public int MaxDialogs = 0;

        private FriendItem selectFriend;
        public FriendItem SelectFriend
        {
            get => selectFriend;
            set
            {
                if (selectFriend == value) return;

                selectFriend = value;
                Changed("SelectFriend");
            }
        }

        public long MaxFriends = -1;
        private Visibility _visibleListViewFriends = Visibility.Collapsed;
        public Visibility VisibleListViewFriends
        {
            get => _visibleListViewFriends;
            set
            {
                if (value == _visibleListViewFriends) return;

                _visibleListViewFriends = value;
                Changed("VisibleListViewFriends");
            }
        }


        private ObservableCollection<FriendItem> _itemsFriends; 
        public ObservableCollection<FriendItem> ItemsFriends
        {
            get => _itemsFriends;
            set
            {
                if (_itemsFriends == value) return;
                else
                {
                    _itemsFriends = value;
                    Changed("ItemsFriends");
                }
            }
        }

        private RelayCommand _openFriendsCommand;
        public RelayCommand OpenFriendsCommand
        {
            get => _openFriendsCommand = _openFriendsCommand ?? new RelayCommand( async() => await GetFriends());
        }

        public async void ListViewFriends_Click(object sender, ItemClickEventArgs e)
        {
            await GetInfoAboutUser();
        }

        private async Task GetFriends()
        {
            TitleText = "Друзья";
            IsOpenDialogs = false;
            IsOpenFriend = true;
            IsOpenSettings = false;
            VisibleListView = Visibility.Collapsed;
            VisibleListViewFriends = Visibility.Visible;
            ItemsFriends = new ObservableCollection<FriendItem>();
            await GetMoreFriends();
        }

        private async Task GetMoreFriends()
        {
            IsLoadingPage = true;
            var friends = await VK.Methods.Friends.List(order: "hints", fields: "sex,online,photo_50, can_write_private_message, online, last_seen");
            MaxFriends = friends.count;
            foreach (var friend in friends.items)
            {
                string name, body = string.Empty;
                Uri photo;
                Visibility online = Visibility.Collapsed;

                name = $"{friend.first_name} {friend.last_name}";
                photo = await DownloaderImages.Dowload(friend.photo_50, $"user_{friend.id}_50.jpg");

                if(friend.deactivated == null ||friend.deactivated != "deleted" || friend.deactivated != "banned")
                {
                    if (friend.online == 1)
                    {
                        online = Visibility.Visible;
                        if (friend.online_mobile == 1)
                        {
                            body = $"Онлайн с {Converts.LastSeenPlatform(friend.last_seen.platform)}";
                        }
                        else
                        {
                            body = $"Онлайн с компьютера";
                        }

                    }
                    else
                    {
                        var date = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(friend.last_seen.time);
                        string time;
                        bool m = false;
                        if (date.Day == DateTime.Now.Day)
                        {
                            m = true;
                            string hour = string.Empty;
                            string minute = string.Empty;
                            if (date.Hour.ToString().Length == 1)
                            {
                                hour = $"0{date.Hour}";
                            }
                            else
                            {
                                hour = date.Hour.ToString();
                            }
                            if (date.Minute.ToString().Length == 1)
                            {
                                minute = $"0{date.Minute}";
                            }
                            else
                            {
                                minute = date.Minute.ToString();
                            }
                            time = $"{hour}:{minute}";
                        }
                        else
                        {
                            time = $"{date.Day} {Converts.Month(date.Month)}";
                        }

                        if (friend.sex == 1)
                        {
                            if (m) body = $"Была в сети в {time}";
                            else body = $"Была в сети {time}";
                        }
                        else
                        {
                            if (m) body = $"Был в сети в {time}";
                            else body = $"Был в сети {time}";
                        }
                    }
                }else
                {
                    body = "Страница удалена или заблокирована";
                }
                

                var elementFriend = new FriendItem()
                {
                    Body = body,
                    Friend = friend,
                    Name = name,
                    Online = online,
                    PhotoUrl = photo
                };

                ItemsFriends.Add(elementFriend);
            }

            IsLoadingPage = false;
        }


        private Visibility visibilityNoDialogs = Visibility.Collapsed;
        public Visibility VisibilityNoDialogs
        {
            get => visibilityNoDialogs;
            set
            {
                if (value == visibilityNoDialogs) return;
                visibilityNoDialogs = value;
                Changed("VisibilityNoDialogs");
            }
        }

        private Visibility _visibleDialogView = Visibility.Collapsed;
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

        private RelayCommand _OpenDialogsCommand;
        public RelayCommand OpenDialogsCommand
        {
            get => _OpenDialogsCommand = _OpenDialogsCommand ?? new RelayCommand(async () => await OpenDialogs());
        }

        private RelayCommand _GetInfoCommand;
        public RelayCommand GetInfoCommand
        {
            get => _GetInfoCommand = _GetInfoCommand ?? new RelayCommand(async () => await GetInfoAboutUser());
        }

        private RelayCommand _openSettingsCommand;
        public RelayCommand OpenSettingsCommand
        {
            get => _openSettingsCommand = _openSettingsCommand ?? new RelayCommand(async () => await OpenSettings());
        }

        private RelayCommand _openNewMessageCommand;
        public RelayCommand OpenNewMessageCommand
        {
            get => _openNewMessageCommand = _openNewMessageCommand ?? new RelayCommand(async () => await OpenNewMessage());
        }

        private async Task OpenNewMessage()
        {
            if (_itemsFriends != null) return;
            else
            {
                ItemsFriends = new ObservableCollection<FriendItem>();

                IsLoadingFriendsNewMessage = true;
                var friends = await VK.Methods.Friends.List(order: "hints", fields: "sex,online,photo_100, can_write_private_message, online, last_seen");
                MaxFriends = friends.count;
                foreach (var friend in friends.items)
                {
                    string name, body = string.Empty;
                    Uri photo;
                    Visibility online = Visibility.Collapsed;

                    name = $"{friend.first_name} {friend.last_name}";
                    photo = await DownloaderImages.Dowload(friend.photo_100, $"user_{friend.id}_100.jpg");

                    if (friend.deactivated == null || friend.deactivated != "deleted" || friend.deactivated != "banned")
                    {
                        if (friend.online == 1)
                        {
                            online = Visibility.Visible;
                            if (friend.online_mobile == 1)
                            {
                                body = $"Онлайн с {Converts.LastSeenPlatform(friend.last_seen.platform)}";
                            }
                            else
                            {
                                body = $"Онлайн с компьютера";
                            }

                        }
                        else
                        {
                            var date = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(friend.last_seen.time);
                            string time;
                            bool m = false;
                            if (date.Day == DateTime.Now.Day)
                            {
                                m = true;
                                string hour = string.Empty;
                                string minute = string.Empty;
                                if (date.Hour.ToString().Length == 1)
                                {
                                    hour = $"0{date.Hour}";
                                }
                                else
                                {
                                    hour = date.Hour.ToString();
                                }
                                if (date.Minute.ToString().Length == 1)
                                {
                                    minute = $"0{date.Minute}";
                                }
                                else
                                {
                                    minute = date.Minute.ToString();
                                }
                                time = $"{hour}:{minute}";
                            }
                            else
                            {
                                time = $"{date.Day} {Converts.Month(date.Month)}";
                            }

                            if (friend.sex == 1)
                            {
                                if (m) body = $"Была в сети в {time}";
                                else body = $"Была в сети {time}";
                            }
                            else
                            {
                                if (m) body = $"Был в сети в {time}";
                                else body = $"Был в сети {time}";
                            }
                        }
                    }
                    else
                    {
                        body = "Страница удалена или заблокирована";
                    }


                    var elementFriend = new FriendItem()
                    {
                        Body = body,
                        Friend = friend,
                        Name = name,
                        Online = online,
                        PhotoUrl = photo
                    };

                    ItemsFriends.Add(elementFriend);
                }

                IsLoadingFriendsNewMessage = false;
            }
        }


        private async Task GetInfoAboutUser()
        {
            if (SelectFriend is null) return;
            var info = new InfoUserDialog();
            info.UserId = SelectFriend.Friend.id;
            await info.ShowAsync();
        }

        private async Task OpenSettings()
        {
            IsOpenSettings = false;

            var dialog = new SettingsDialog();
            await dialog.ShowAsync();
        }


        private async Task OpenDialogs()
        {
            TitleText = "Диалоги";

            if (IsOpenFriend)
            {
                 IsOpenFriend = false;
                VisibleListViewFriends = Visibility.Collapsed;
                VisibleListView = Visibility.Visible;
            }else
            {
                IsOpenFriend = false;
                IsOpenDialogs = true;
                IsOpenSettings = false;
                await GetDialogs();
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

        private Visibility _visibleNoSelectDialogView = Visibility.Visible;
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

        public void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OpenDialogPage();
        }

        public async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            await OpenDialogPage();
        }

        public int maxCount = -1;

        public async Task<List<DialogsElementModel>> GetMoreDialogs(CancellationToken token, uint countDialog)
        {
            IsLoadingPage = true;

            var collection = new ObservableCollection<DialogsElementModel>();

            var dialogs = await VK.Methods.Conversations.List(50, ItemsDialogs.Count);

            if (dialogs.items.Count == 0) VisibilityNoDialogs = Visibility.Visible;

            maxCount = (int)dialogs.count;
           

            if (dialogs.unread_count > 0)
            {
                var countUnreadAll = string.Empty;
                var countUnreadAllE = dialogs.unread_count;

                if (countUnreadAllE > 1000 && countUnreadAllE < 1000000)
                {
                    var i = countUnreadAllE / 1000;
                    countUnreadAll = $"{i}K";
                }
                else if (countUnreadAllE > 1000000)
                {
                    var i = countUnreadAllE / 1000000;
                    countUnreadAll = $"{i}M";
                }
                else
                {
                    countUnreadAll = countUnreadAllE.ToString();
                }

                CountUnread = countUnreadAll;


                int widthAll = 25;
                switch (countUnreadAll.Length)
                {
                    case 0:
                        widthAll = 0;
                        break;
                    case 1:
                        widthAll = 25;
                        break;
                    case 2:
                        widthAll = 30;
                        break;
                    case 3:
                        widthAll = 35;
                        break;
                    case 4:
                        widthAll = 45;
                        break;
                    case 5:
                        widthAll = 55;
                        break;
                    case 6:
                        widthAll = 65;
                        break;
                    case 7:
                        widthAll = 70;
                        break;
                    default:
                        widthAll = 25;
                        break;
                }

                WidthUnread = widthAll;
                VisibilityUnread = Visibility.Visible;
            }

            var listUserIds = new List<long>();
            var listGroupsIds = new List<long>();
            var listNamesUds = new Dictionary<long, long>();
            List<long> namesIds = new List<long>();


            var me = await StaticContent.Me();
            var meId = me.id;

            

            foreach (var item in dialogs.items)
            {
                string title = string.Empty;
                string body = string.Empty;
                string name = string.Empty;
                long id = 0;
                Uri photoUrl = new Uri("ms-appx:///Images/PhotoUser.jpg");
                long countUnread = 0;
                Visibility visibleUnread = Visibility.Collapsed;
                Visibility muteNotifications = Visibility.Collapsed;
                string time = string.Empty;

                if (item.conversation.peer.type == "user")
                {
                    id = item.conversation.peer.id;
                    listUserIds.Add(id);

                    if (item.last_message.from_id == meId)
                    {
                        name = "Вы: ";
                    }
                    else
                    {
                        name = string.Empty;
                    }
                }
                else if (item.conversation.peer.type == "chat")
                {
                    id = item.conversation.peer.id - 2000000000;
                    title = item.conversation.chat_settings.title;
                    if (item.conversation.chat_settings.photo != null)
                    {
                        photoUrl = await DownloaderImages.Dowload(item.conversation.chat_settings.photo.photo_50, $"chat_{id}_50.jpg");
                    }

                    if (item.last_message.from_id == meId)
                    {
                        name = "Вы: ";
                    }
                    else
                    {
                        listNamesUds.Add(id, item.last_message.from_id);
                    }
                }
                else if (item.conversation.peer.type == "email")
                {
                    id = (item.conversation.peer.id + 2000000000) * (-1);
                }
                else if (item.conversation.peer.type == "group")
                {
                    id = item.conversation.peer.id * (-1);
                    listGroupsIds.Add(id);
                }

                countUnread = item.conversation.unread_count;
                if (countUnread > 0) visibleUnread = Visibility.Visible;

                /*if(item.conversation.peer.type == "chat")
                {
                    if (item.conversation.push_settings.no_sound || item.conversation.push_settings.disabled_forever)
                        muteNotifications = Visibility.Visible;
                }*/

                if (item.last_message.action != null)
                {
                    switch (item.last_message.action.type)
                    {
                        case "chat_photo_update":
                            body = "Обновил фотографию беседы";
                            break;
                        case "chat_photo_remove":
                            body = "Удалил фотографию беседы";
                            break;
                        case "chat_create":
                            body = "Создал беседу";
                            break;
                        case "chat_title_update":
                            body = "Изменил название беседы";
                            break;
                        case "chat_invite_user":
                            body = "Пригласил пользователя";
                            break;
                        case "chat_kick_user":
                            body = "Исключил пользователя";
                            break;
                        case "chat_pin_message":
                            body = "Закрепил сообщение";
                            break;
                        case "chat_unpin_message":
                            body = "Открепил сообщение";
                            break;
                        case "chat_invite_user_by_link":
                            body = "Присоеденился по ссылке";
                            break;
                        default:
                            body = "...";
                            break;
                    }
                }
                else if (item.last_message.attachments != null)
                {
                    if (item.last_message.attachments.Count != 0)
                    {
                        var attachents = item.last_message.attachments;
                        if (attachents.Count < 2) body = attachents.FirstOrDefault().Instanse.ToString();
                        else
                        {
                            var countAtt = attachents.Count;
                            var type = attachents.FirstOrDefault().TypeAttach;
                            bool result = false;
                            foreach (var attach in attachents)
                            {
                                if (attach.TypeAttach == type) result = true;
                                else
                                {
                                    result = false;
                                    break;
                                }
                            }

                            if (result)
                            {
                                var att = attachents.FirstOrDefault();
                                if (att.TypeAttach == typeof(Audio))
                                {
                                    var attach = (Audio)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                                else if (att.TypeAttach == typeof(Document))
                                {
                                    var attach = (Document)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                                else if (att.TypeAttach == typeof(Link))
                                {
                                    var attach = (Link)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                                else if (att.TypeAttach == typeof(Market))
                                {
                                    var attach = (Market)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                                else if (att.TypeAttach == typeof(MarketAlbum))
                                {
                                    var attach = (MarketAlbum)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                                else if (att.TypeAttach == typeof(VK.Models.Attachments.Photo))
                                {
                                    var attach = (VK.Models.Attachments.Photo)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                                else if (att.TypeAttach == typeof(Video))
                                {
                                    var attach = (Video)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                                else if (att.TypeAttach == typeof(Undefined))
                                {
                                    var attach = (Undefined)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                                else
                                {
                                    var attach = (Undefined)att.Instanse;
                                    body = $"{countAtt} {attach.ToMore()}";
                                }
                            }
                            else
                            {
                                body = $"{countAtt} вложений";
                            }
                        }
                    }
                    else
                    {
                        body = item.last_message.text;
                        body = body.Replace("\n", " ");
                        if (body.Length > 70)
                        {
                            body = body.Substring(0, 60) + "...";
                        }
                    }
                }else if(item.last_message.fwd_messages != null)
                {
                    body = $"{item.last_message.fwd_messages.Count} пересланных сообщений";
                }
                else
                {
                    body = item.last_message.text;
                    body = body.Replace("\n", " ");
                    if (body.Length > 70)
                    {
                        body = body.Substring(0, 60) + "...";
                    }
                }

                time = Converts.ToDateString(item.last_message.date);

                string countUnreadStr = string.Empty;
                if (countUnread > 1000 && countUnread < 1000000)
                {
                    var i = countUnread / 1000;
                    countUnreadStr = $"{i}K";
                }
                else if (countUnread > 1000000)
                {
                    var i = countUnread / 1000000;
                    countUnreadStr = $"{i}M";
                }
                else
                {
                    countUnreadStr = countUnread.ToString();
                }

                int width = 25;
                switch (countUnreadStr.Length)
                {
                    case 0:
                        width = 0;
                        break;
                    case 1:
                        width = 25;
                        break;
                    case 2:
                        width = 30;
                        break;
                    case 3:
                        width = 35;
                        break;
                    case 4:
                        width = 45;
                        break;
                    case 5:
                        width = 55;
                        break;
                    case 6:
                        width = 65;
                        break;
                    case 7:
                        width = 70;
                        break;
                    default:
                        width = 25;
                        break;
                }

                var element = new DialogsElementModel()
                {
                    Title = title,
                    Body = body,
                    Name = name,
                    Id = id,
                    PhotoUrl = photoUrl,
                    CountUnread = countUnreadStr,
                    VisibleUnread = visibleUnread,
                    MuteNotifications = muteNotifications,
                    Time = time,
                    WidthUnread = width,
                    Conversation = item
                };

                collection.Add(element);
            }

            List<User> userNames = null;

            if (listUserIds.Count > 0)
            {
                userNames = await VK.Methods.Users.Get(listUserIds, fields: "photo_50");

                foreach (var user in userNames)
                {
                    var element = collection.Where((u) => u.Id == user.id).FirstOrDefault();
                    collection.Remove(element);

                    element.Title = $"{user.first_name} {user.last_name}";

                    if (element.PhotoUrl == new Uri("ms-appx:///Images/PhotoUser.jpg"))
                    {
                        element.PhotoUrl = await DownloaderImages.Dowload(user.photo_50, $"user_{user.id}_50.jpg");
                    }
                    collection.Add(element);
                }
            }


            if (listGroupsIds.Count > 0)
            {
                var groupsNames = await VK.Methods.Groups.Get(listGroupsIds);

                foreach (var group in groupsNames)
                {
                    var element = collection.Where((u) => u.Id == group.id).FirstOrDefault();
                    collection.Remove(element);

                    element.Title = group.name;

                    if (element.PhotoUrl == new Uri("ms-appx:///Images/PhotoUser.jpg"))
                    {
                        element.PhotoUrl = await DownloaderImages.Dowload(group.photo_50, $"group_{group.id}_50.jpg");
                    }
                    collection.Add(element);
                }
            }


            if (listNamesUds.Count > 0)
            {
                foreach (var name in listNamesUds)
                {
                    if (listUserIds.Any((u) => u == name.Value) && userNames != null)
                    {
                        var element = collection.Where((u) => u.Id == name.Key).FirstOrDefault();
                        collection.Remove(element);

                        var user = userNames.Where((u) => u.id == name.Value).FirstOrDefault();
                        element.Name = user.first_name;
                        collection.Add(element);
                    }
                    else
                    {
                        namesIds.Add(name.Value);
                    }
                }
            }


            if (namesIds.Count > 0)
            {
                var names = await VK.Methods.Users.Get(namesIds);

                foreach (var user in names)
                {
                    var dialog = listNamesUds.Where((u) => u.Value == user.id).FirstOrDefault();
                    if (dialog.Key != 0)
                    {
                        var element = collection.Where(u => u.Id == dialog.Key).FirstOrDefault();
                        if (element != null)
                        {
                            collection.Remove(element);
                            element.Name = $"{user.first_name}: ";
                            collection.Add(element);
                        }
                    }
                }
            }

            dialogs = null;
            listUserIds = null;
            listGroupsIds = null;
            listNamesUds = null;
            namesIds = null;
            me = null;
            meId = 0;
            var newCollection = collection.OrderByDescending(u => u.Conversation.last_message.date);
            var returnCollecton = new List<DialogsElementModel>();
            foreach (var element in newCollection)
            {
                returnCollecton.Add(element);
            }

            IsLoadingPage = false;

            return returnCollecton;
        }

            
        private async void AddedNewMessageDialogs(VK.Models.LongPoll.AddNewMsgModel arg)
        {
            if(ItemsDialogs.Count != 0)
            {
                string text = arg.Text;
                long id;
                long userSend;
                bool isDialog = false;
                if (arg.Attachments.from == 0)
                {
                    id = arg.PeerId;
                    isDialog = true;
                    userSend = 0;
                }
                else
                {
                    id = arg.PeerId - 2000000000;
                    if (id < 0) id = Int64.Parse(arg.PeerId.ToString().Replace("-", ""));
                    userSend = arg.Attachments.from;
                }
                var time = Converts.ToDateString(arg.Time);
                var elements = ItemsDialogs.Where(u => u.Id == id);
                if(elements.Count() > 0)
                {
                    var element = elements.First();
                    var index = ItemsDialogs.IndexOf(element);
                    if(isDialog)
                    {
                        element.Body = text;
                    }else
                    {
                        var name = (await VK.Methods.Users.Get(new List<long> { userSend })).First().first_name;
                        element.Name = name;
                        element.Body = text;
                    }
                    ItemsDialogs.RemoveAt(index);
                    ItemsDialogs.Insert(0, element);
                }

            }
        }

        public async Task GetDialogs()
        {
            if(!longPollService.IsRunning) await longPollService.RunAsync();

            longPollService.AddNewMsgEvent += AddedNewMessageDialogs;
            VisibleListView = Visibility.Visible;
            VisibleListViewFriends = Visibility.Collapsed;
            ItemsDialogs = new LoadingCollection<DialogsElementModel>();
            ItemsDialogs.OnMoreItemsRequested = GetMoreDialogs;
            ItemsDialogs.HasMoreItemsRequested = () =>
            {
                if (maxCount == 0) return false;
                else if (maxCount == -1) return true;
                else return ItemsDialogs.Count < maxCount;
            };
        }


        private async Task OpenDialogPage()
        {
            if(VisibleDialogView == Visibility.Collapsed)
            {
                VisibleDialogView = Visibility.Visible;
                VisibleNoSelectDialogView = Visibility.Collapsed;
            }

            var vm = MessagesViewModel.GetVM();
            await vm.StartLoading(SelectItemDialog);
        }

        private LoadingCollection<DialogsElementModel> _itemsDialogs;
        public LoadingCollection<DialogsElementModel> ItemsDialogs 
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

        private Visibility _visibilityUnread = Visibility.Collapsed;
        public Visibility VisibilityUnread
        {
            get => _visibilityUnread;
            set
            {
                if (value == _visibilityUnread) return;

                _visibilityUnread = value;
                Changed("VisibilityUnread");
            }
        }

        private int _widthUnread = 0;
        public int WidthUnread
        {
            get => _widthUnread;
            set
            {
                if (value == _widthUnread) return;

                _widthUnread = value;
                Changed("WidthUnread");
            }
        }

        private string _countUnread = string.Empty;
        public string CountUnread
        {
            get => _countUnread;
            set
            {
                if (value == _countUnread) return;

                _countUnread = value;
                Changed("CountUnread");
            }
        }

        private Visibility _isVisibleBack = Visibility.Collapsed;
        public Visibility IsVisibleBlack
        {
            get => _isVisibleBack;
            set
            {
                if (value == _isVisibleBack) return;

                _isVisibleBack = value;
                Changed("IsVisibleBlack");
            }
        }

        private bool _isLoadingPage;
        public bool IsLoadingPage
        {
            get => _isLoadingPage;
            set
            {
                if (value == _isLoadingPage) return;

                if (value) IsVisibleBlack = Visibility.Visible;
                else IsVisibleBlack = Visibility.Collapsed;

                _isLoadingPage = value;
                Changed("IsLoadingPage");
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

        private bool _isLoadingFriendsNewMessage= false;
        public bool IsLoadingFriendsNewMessage
        {
            get => _isLoadingFriendsNewMessage;
            set
            {
                if (value == _isLoadingFriendsNewMessage) return;

                _isLoadingFriendsNewMessage = value;
                Changed("IsLoadingFriendsNewMessage");
            }
        }
    }
}
