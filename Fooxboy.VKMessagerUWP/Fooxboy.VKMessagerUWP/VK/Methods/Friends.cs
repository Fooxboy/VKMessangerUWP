using Fooxboy.VKMessagerUWP.VK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Methods
{
    public static class Friends
    {
        public async static Task<FriendsList> List(long id = 0, string order= "name", long list_id=0, int count=0, int offset = 0, string fields = "sex", string name_case= "nom")
        {
            string list_idStr = string.Empty;
            string countStr = string.Empty;

            if (list_id != 0) list_idStr = list_id.ToString();
            if (count != 0) countStr = count.ToString();

            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                ["user_id"] = id.ToString(),
                ["order"] = order,
                ["list_id"] = list_idStr,
                ["count"] = countStr,
                ["offset"] = offset.ToString(),
                ["fields"] = fields,
                ["name_case"] = name_case
            };

            var result = await Call<FriendsList>.Method("friends.get", param);
            return result;
        }
    }
}
