using Fooxboy.VKMessagerUWP.VK.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Fooxboy.VKMessagerUWP.VK.Models;
using Fooxboy.VKMessagerUWP.Exceptions;
using Fooxboy.VKMessagerUWP.VK.Models.LongPoll;
using Newtonsoft.Json.Linq;

namespace Fooxboy.VKMessagerUWP.VK
{
    public class LongPollService
    {
        public event Delegates.ReplaceMsgFlagDelegate ReplaceMsgFlagEvent;
        public event Delegates.InstallMsgFlagDelegate InstallMsgFlagEvent;
        public event Delegates.ResetMsgFlagDelegate ResetMsgFlagEvent;
        public event Delegates.AddNewMsgDelegate AddNewMsgEvent;
        public event Delegates.EditMsgDelegate EditMsgEvent;
        public event Delegates.ReadAllInMsgDelegate ReadAllInMsEvent;
        public event Delegates.ReadAllOutMsgDelegate ReadAllOutMsEvent;
        public event Delegates.FriendOnlineDelegate FriendOnlineEvent;
        public event Delegates.FriendOfflineDelegate FriendOfflineEvent;
        public event Delegates.ResetDialogFlagDelegate ResetDialogFlagEvent;
        public event Delegates.ReplaceDialogFlagDelegate ReplaceDialogFlagEvent;
        public event Delegates.InstallDialogFlagDelegate InstallDialogFlagEvent;
        public event Delegates.DeletingsAllMsgDelegate DeletingsAllMsgEvent;
        public event Delegates.RestoreDeleteMsgDelegate RestoreDeleteMsgEvent;
        public event Delegates.OneParamChangedDelegate OneParamChangedEvent;
        public event Delegates.EditInfoChatDelegate EditInfoChatEvent;
        public event Delegates.UserTypingInDialogDelegate UserTypingInDialogEvent;
        public event Delegates.UserTypingInChatDelegate UserTypingInChatEvent;
        public event Delegates.UserCompletedCallDelegate UserCompletedCallEvent;
        public event Delegates.UnReadMessageCounterDelegate UnReadMessageCounterEvent;
        public event Delegates.NotificationSettingsChangedDelegate NotificationSettingsChangedEvent;

        public string Server;
        public string Key;
        public long Ts;

        public async Task RunAsync()
        {
            if(Server is null)
            {
                var modelServer = await Messages.LongPoll();
                Server = modelServer.server;
                Key = modelServer.key;
                Ts = modelServer.ts;
            }

            while (true)
            {
                //Делаем запрос к серверу ВКонтакте.
                string json = await Request();

                //Десериализируем ответ
                var longPollObject = JsonConvert.DeserializeObject<RootLongPoll>(json);
                if (longPollObject.Updates is null)
                {
                    var error = JsonConvert.DeserializeObject<ErrorLongPoll>(json);
                    if (error.failed == 1) Ts = error.ts;
                    else if (error.failed == 4) throw new UnknownVersionLongPoll($"Минимальная версия: {error.min_version} Максимальная версия: {error.max_version}");
                    else
                    {
                        var newValueServer = await Messages.LongPoll();
                        Server = newValueServer.server;
                        Key = newValueServer.key;
                        Ts = newValueServer.ts;
                    }
                }
                else
                {
                    Ts = longPollObject.Ts;
                    var updates = longPollObject.Updates;
                    foreach (var update in updates)
                    {
                        int code = (int)update[0];

                        if (code == 1)
                        {
                            var model = new ReplaceMsgFlagModel()
                            {
                                MessageId = (long)update[1],
                                Flags = (long)update[2],
                                PeerId = (long)update[3],
                                Time = (long)update[4],
                                Text = (string)update[5],
                                Attachments = ((JObject)update[6]).ToObject<Attachments>(),
                            };
                            var a = ReplaceMsgFlagEvent?.BeginInvoke(model, null, null);
                            //ReplaceMsgFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 2)
                        {
                            var model = new InstallMsgFlagModel()
                            {
                                MessageId = (long)update[1],
                                Mask = (long)update[2],
                                PeerId = (long)update[3],
                                Time = (long)update[4],
                                Text = (string)update[5],
                                Attachments = ((JObject)update[6]).ToObject<Attachments>(),
                            };
                            var a = InstallMsgFlagEvent?.BeginInvoke(model, null, null);
                            //InstallMsgFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 3)
                        {
                            var model = new ResetMsgFlagModel()
                            {
                                MessageId = (long)update[1],
                                Mask = (long)update[2],
                                PeerId = (long)update[3],
                                Time = (long)update[4],
                                Text = (string)update[5],
                                Attachments = ((JObject)update[6]).ToObject<Attachments>(),
                            };
                            var a = ResetMsgFlagEvent?.BeginInvoke(model, null, null);
                            //ResetMsgFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 4)
                        {
                            var model = new AddNewMsgModel()
                            {
                                MessageId = (long)update[1],
                                Flags = (long)update[2],
                                PeerId = (long)update[3],
                                Time = (long)update[4],
                                Text = (string)update[5],
                                Attachments = ((JObject)update[6]).ToObject<Attachments>(),
                            };
                            var a = AddNewMsgEvent?.BeginInvoke(model, null, null);
                            //AddNewMsgEvent?.EndInvoke(a);
                        }
                        else if (code == 5)
                        {
                            var model = new EditMsgModel()
                            {
                                MessageId = (long)update[1],
                                Mask = (long)update[2],
                                PeerId = (long)update[3],
                                Time = (long)update[4],
                                NewText = (string)update[5],
                                Attachments = ((JObject)update[6]).ToObject<Attachments>()
                            };
                            var a = EditMsgEvent?.BeginInvoke(model, null, null);
                            //EditMsgEvent?.EndInvoke(a);
                        }
                        else if (code == 6)
                        {
                            var model = new ReadAllInMsgModel()
                            {
                                PeerId = (long)update[1],
                                LocalId = (long)update[2]
                            };
                            var a = ReadAllInMsEvent?.BeginInvoke(model, null, null);
                            //ReadAllInMsEvent?.EndInvoke(a);
                        }
                        else if (code == 7)
                        {
                            var model = new ReadAllOutMsgModel()
                            {
                                PeerId = (long)update[1],
                                LocalId = (long)update[2]
                            };
                            var a = ReadAllOutMsEvent?.BeginInvoke(model, null, null);
                            //ReadAllOutMsEvent?.EndInvoke(a);
                        }
                        else if (code == 8)
                        {
                            var model = new FriendOnlineModel()
                            {
                                UserId = (long)update[1],
                                Platform = (long)update[2],
                                Time = (long)update[3]
                            };
                            var a = FriendOnlineEvent?.BeginInvoke(model, null, null);
                            //FriendOnlineEvent?.EndInvoke(a);
                        }
                        else if (code == 9)
                        {
                            var model = new FriendOfflineModel()
                            {
                                UserId = (long)update[1],
                                Flags = (long)update[2],
                                Time = (long)update[3]
                            };
                            var a = FriendOfflineEvent?.BeginInvoke(model, null, null);
                            //FriendOfflineEvent?.EndInvoke(a);
                        }
                        else if (code == 10)
                        {
                            var model = new ResetDialogFlagModel()
                            {
                                PeerId = (long)update[1],
                                Mask = (long)update[2]
                            };
                            var a = ResetDialogFlagEvent?.BeginInvoke(model, null, null);
                            //ResetDialogFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 11)
                        {
                            var model = new ReplaceDialogFlagModel()
                            {
                                PeerId = (long)update[1],
                                Flags = (long)update[2]
                            };
                            var a = ReplaceDialogFlagEvent?.BeginInvoke(model, null, null);
                            //ReplaceDialogFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 12)
                        {
                            var model = new InstallDialogFlagModel()
                            {
                                PeerId = (long)update[1],
                                Mask = (long)update[2]
                            };
                            var a = InstallDialogFlagEvent?.BeginInvoke(model, null, null);
                            //InstallDialogFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 13)
                        {
                            var model = new DeletingsAllMsgModel()
                            {
                                PeerId = (long)update[1],
                                LocalId = (long)update[2]
                            };
                            var a = DeletingsAllMsgEvent?.BeginInvoke(model, null, null);
                            //DeletingsAllMsgEvent?.EndInvoke(a);
                        }
                        else if (code == 14)
                        {
                            var model = new RestoreDeleteMsgModel()
                            {
                                PeerId = (long)update[1],
                                LocalId = (long)update[2]
                            };
                            var a = RestoreDeleteMsgEvent?.BeginInvoke(model, null, null);
                            //RestoreDeleteMsgEvent?.EndInvoke(a);
                        }
                        else if (code == 51)
                        {
                            var model = new OneParamChangedModel()
                            {
                                ChatId = (long)update[1],
                                Self = (long)update[2]
                            };
                            var a = OneParamChangedEvent?.BeginInvoke(model, null, null);
                            //OneParamChangedEvent?.EndInvoke(a);
                        }
                        else if (code == 52)
                        {
                            var model = new EditInfoChatModel()
                            {
                                TypeId = (long)update[1],
                                PeerId = (long)update[2],
                                Info = (long)update[3]
                            };
                            var a = EditInfoChatEvent?.BeginInvoke(model, null, null);
                            //EditInfoChatEvent?.EndInvoke(a);
                        }
                        else if (code == 61)
                        {
                            var model = new UserTypingInDialogModel()
                            {
                                UserId = (long)update[1],
                                Flags = (long)update[2]
                            };
                            var a = UserTypingInDialogEvent?.BeginInvoke(model, null, null);
                            //UserTypingInDialogEvent?.EndInvoke(a);
                        }
                        else if (code == 62)
                        {
                            var model = new UserTypingInChatModel()
                            {
                                UserId = (long)update[1],
                                ChatId = (long)update[2]
                            };
                            var a = UserTypingInChatEvent?.BeginInvoke(model, null, null);
                            //UserTypingInChatEvent?.EndInvoke(a);
                        }
                        else if (code == 70)
                        {
                            var model = new UserCompletedCallModel()
                            {
                                UserId = (long)update[1],
                                CallId = (long)update[2]
                            };
                            var a = UserCompletedCallEvent?.BeginInvoke(model, null, null);
                            //UserCompletedCallEvent?.EndInvoke(a);
                        }
                        else if (code == 80)
                        {
                            var model = new UnReadMessageCounterModel() { Count = (long)update[1] };
                            var a = UnReadMessageCounterEvent?.BeginInvoke(model, null, null);
                            //UnReadMessageCounterEvent?.EndInvoke(a);
                        }
                        else if (code == 114)
                        {
                            var model = new NotificationSettingsChangedModel()
                            {
                                PeerId = (long)update[1],
                                Second = (long)update[2],
                                DisabledUntil = (long)update[3]
                            };
                            var a = NotificationSettingsChangedEvent?.BeginInvoke(model, null, null);
                            //NotificationSettingsChangedEvent?.EndInvoke(a);
                        }else
                        {
                            //Неизвестный код обновления
                        }
                    }
                }
            }
        }

        private async Task<string> Request()
        {
            string url = $"https://{Server}?act=a_check&key={Key}&ts={Ts}&wait=25&mode=2&version=3";
            string json = string.Empty;
            using(var client = new WebClient())
            {
               json = await client.DownloadStringTaskAsync(url);
            }
            return json;
        }
    }
}
