using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.LongPoll
{
    public class Delegates
    {
        public delegate void ReplaceMsgFlagDelegate(ReplaceMsgFlagModel args);
        public delegate void InstallMsgFlagDelegate(InstallMsgFlagModel args);
        public delegate void ResetMsgFlagDelegate(ResetMsgFlagModel args);
        public delegate void AddNewMsgDelegate(AddNewMsgModel args);
        public delegate void EditMsgDelegate(EditMsgModel args);
        public delegate void ReadAllInMsgDelegate(ReadAllInMsgModel args);
        public delegate void ReadAllOutMsgDelegate(ReadAllOutMsgModel args);
        public delegate void FriendOnlineDelegate(FriendOnlineModel args);
        public delegate void FriendOfflineDelegate(FriendOfflineModel args);
        public delegate void ResetDialogFlagDelegate(ResetDialogFlagModel args);
        public delegate void ReplaceDialogFlagDelegate(ReplaceDialogFlagModel args);
        public delegate void InstallDialogFlagDelegate(InstallDialogFlagModel args);
        public delegate void DeletingsAllMsgDelegate(DeletingsAllMsgModel args);
        public delegate void RestoreDeleteMsgDelegate(RestoreDeleteMsgModel args);
        public delegate void OneParamChangedDelegate(OneParamChangedModel args);
        public delegate void EditInfoChatDelegate(EditInfoChatModel args);
        public delegate void UserTypingInDialogDelegate(UserTypingInDialogModel args);
        public delegate void UserTypingInChatDelegate(UserTypingInChatModel args);
        public delegate void UserCompletedCallDelegate(UserCompletedCallModel args);
        public delegate void UnReadMessageCounterDelegate(UnReadMessageCounterModel args);
        public delegate void NotificationSettingsChangedDelegate(NotificationSettingsChangedModel args);
    }
}
