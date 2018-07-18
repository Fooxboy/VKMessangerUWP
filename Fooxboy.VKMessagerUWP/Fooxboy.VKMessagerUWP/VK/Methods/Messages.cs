using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Methods
{
    public static class Messages
    {
        public async static Task<Models.HistoryMessage> History(long user_id =0, long peer_id = 0, int offset=0, int count=0, int start_message_id=0, int rev=1, int extended =1, string fields = "", long group_id=0)
        {
            Dictionary<string, string> parametrs = new Dictionary<string, string>()
            {
                ["user_id"] = user_id.ToString(),
                ["peer_id"] = peer_id.ToString(),
                ["offset"] = offset.ToString(),
                ["count"] = count.ToString(),
                ["start_message_id"] = start_message_id.ToString(),
                ["rev"] = rev.ToString(),
                ["extended"] = extended.ToString(),
                ["fields"] = fields,
                ["group_id"] = group_id.ToString()
            };

            var result = await Call<Models.HistoryMessage>.Method("messages.getHistory", parametrs);
            return result;
        }
    }
}
