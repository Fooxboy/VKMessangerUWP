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

        public bool IsRunning { get; set; }

        public string Server;
        public string Key;
        public long Ts;

        public async Task RunAsync()
        {
            Logger.Info("Старт longpoll...");
            IsRunning = true;
            if(Server is null)
            {
                Logger.Info("Получение KeyAndServer...");
                var modelServer = await Messages.LongPoll();
                Server = modelServer.server;
                Key = modelServer.key;
                Ts = modelServer.ts;
            }

            while (IsRunning)
            {
                Logger.Info("Запрос к longpoll серверу ВКонтакте...");
                //Делаем запрос к серверу ВКонтакте.
                string json = await Request();
                Logger.Json(json);

                //Десериализируем ответ
                var longPollObject = JsonConvert.DeserializeObject<RootLongPoll>(json);
                Logger.Info("Десериализируем полученные данные.");
                if (longPollObject.Updates is null)
                {

                    var error = JsonConvert.DeserializeObject<ErrorLongPoll>(json);
                    Logger.Error($"Произошла ошибка при получении обновлений LongPoll. Код: {error.failed}");
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
                    Logger.Info("Старт обработки ответа...");
                    Ts = longPollObject.Ts;
                    var updates = longPollObject.Updates;
                    foreach (var update in updates)
                    {
                        var code = (long)update[0];
                        Logger.Info($"Обработка кода {code}");

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
                            ReplaceMsgFlagEvent?.Invoke(model);
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
                            InstallMsgFlagEvent?.Invoke(model);
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
                            ResetMsgFlagEvent?.Invoke(model);
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
                            AddNewMsgEvent?.Invoke(model);
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
                            EditMsgEvent?.Invoke(model);
                            //EditMsgEvent?.EndInvoke(a);
                        }
                        else if (code == 6)
                        {
                            var model = new ReadAllInMsgModel()
                            {
                                PeerId = (long)update[1],
                                LocalId = (long)update[2]
                            };
                           ReadAllInMsEvent?.Invoke(model);
                            //ReadAllInMsEvent?.EndInvoke(a);
                        }
                        else if (code == 7)
                        {
                            var model = new ReadAllOutMsgModel()
                            {
                                PeerId = (long)update[1],
                                LocalId = (long)update[2]
                            };
                            ReadAllOutMsEvent?.Invoke(model);
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
                            FriendOnlineEvent?.Invoke(model);
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
                            FriendOfflineEvent?.Invoke(model);
                            //FriendOfflineEvent?.EndInvoke(a);
                        }
                        else if (code == 10)
                        {
                            var model = new ResetDialogFlagModel()
                            {
                                PeerId = (long)update[1],
                                Mask = (long)update[2]
                            };
                            ResetDialogFlagEvent?.Invoke(model);
                            //ResetDialogFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 11)
                        {
                            var model = new ReplaceDialogFlagModel()
                            {
                                PeerId = (long)update[1],
                                Flags = (long)update[2]
                            };
                            ReplaceDialogFlagEvent?.Invoke(model);
                            //ReplaceDialogFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 12)
                        {
                            var model = new InstallDialogFlagModel()
                            {
                                PeerId = (long)update[1],
                                Mask = (long)update[2]
                            };
                           InstallDialogFlagEvent?.Invoke(model);
                            //InstallDialogFlagEvent?.EndInvoke(a);
                        }
                        else if (code == 13)
                        {
                            var model = new DeletingsAllMsgModel()
                            {
                                PeerId = (long)update[1],
                                LocalId = (long)update[2]
                            };
                           DeletingsAllMsgEvent?.Invoke(model);
                            //DeletingsAllMsgEvent?.EndInvoke(a);
                        }
                        else if (code == 14)
                        {
                            var model = new RestoreDeleteMsgModel()
                            {
                                PeerId = (long)update[1],
                                LocalId = (long)update[2]
                            };
                            RestoreDeleteMsgEvent?.Invoke(model);
                            //RestoreDeleteMsgEvent?.EndInvoke(a);
                        }
                        else if (code == 51)
                        {
                            /*
                            var model = new OneParamChangedModel()
                            {
                                ChatId = (long)update[1],
                                Self = (long)update[2]
                            };
                            OneParamChangedEvent?.Invoke(model);
                            //OneParamChangedEvent?.EndInvoke(a);*/
                        }
                        else if (code == 52)
                        {
                            var model = new EditInfoChatModel()
                            {
                                TypeId = (long)update[1],
                                PeerId = (long)update[2],
                                Info = (long)update[3]
                            };
                            EditInfoChatEvent?.Invoke(model);
                            //EditInfoChatEvent?.EndInvoke(a);
                        }
                        else if (code == 61)
                        {
                            var model = new UserTypingInDialogModel()
                            {
                                UserId = (long)update[1],
                                Flags = (long)update[2]
                            };
                            UserTypingInDialogEvent?.Invoke(model);
                            //UserTypingInDialogEvent?.EndInvoke(a);
                        }
                        else if (code == 62)
                        {
                            var model = new UserTypingInChatModel()
                            {
                                UserId = (long)update[1],
                                ChatId = (long)update[2]
                            };
                            UserTypingInChatEvent?.Invoke(model);
                            //UserTypingInChatEvent?.EndInvoke(a);
                        }
                        else if (code == 70)
                        {
                            var model = new UserCompletedCallModel()
                            {
                                UserId = (long)update[1],
                                CallId = (long)update[2]
                            };
                            UserCompletedCallEvent?.Invoke(model);
                            //UserCompletedCallEvent?.EndInvoke(a);
                        }
                        else if (code == 80)
                        {
                            var model = new UnReadMessageCounterModel() { Count = (long)update[1] };
                           UnReadMessageCounterEvent?.Invoke(model);
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
                            NotificationSettingsChangedEvent?.Invoke(model);
                            //NotificationSettingsChangedEvent?.EndInvoke(a);
                        }else
                        {
                            Logger.Error($"Неизвестный код обновления LongPoll - {code}");
                        }
                    }
                    Logger.Info("Конец обработки ответа...");
                }
            }
            IsRunning = false;
        }

        private async Task<string> Request()
        {
            string url = $"https://{Server}?act=a_check&key={Key}&ts={Ts}&wait=25&mode=2&version=3";
            string json = string.Empty;
            Logger.Info($"Запрос к url {url}");
            using(var client = new WebClient())
            {
               json = await client.DownloadStringTaskAsync(url);
            }
            Logger.Info("Ответ получен.");
            return json;
        }
    }
}
