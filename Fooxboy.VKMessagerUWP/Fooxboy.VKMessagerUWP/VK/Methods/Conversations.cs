using Fooxboy.VKMessagerUWP.VK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Methods
{
    public static class Conversations
    {
        public async static Task<ConversationsList> List(int count, long offset=0, string filter="all",int extended= 0, long start_message_id = 0,  string fields = "", long group_id = 0)
        {
            string countStr = string.Empty;
            string offsetStr = string.Empty;
            string start_message_idStr = string.Empty;
            string group_idStr = string.Empty;
            string fieldsStr = string.Empty;

            if (count != 0) countStr = count.ToString();
            if (offset != 0) offsetStr = offset.ToString();
            if (start_message_id != 0) start_message_idStr = start_message_id.ToString();
            if (group_id != 0) group_idStr = group_id.ToString();
            if (fields != "") fieldsStr = fields;

            Dictionary<string, string> paramets = new Dictionary<string, string>()
            {
                ["count"] = countStr,
                ["offset"] = offsetStr,
                ["filter"] = filter,
                ["extended"] = extended.ToString(),
                ["start_message_id"] = start_message_idStr,
                ["fields"] = fieldsStr,
                ["group_id"] = group_idStr
            };

            var result = await Call<ConversationsList>.Method("messages.getConversations", paramets);
            return result;
        }
    }
}
