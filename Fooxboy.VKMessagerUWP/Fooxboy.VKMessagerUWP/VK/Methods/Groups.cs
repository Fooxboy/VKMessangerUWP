using Fooxboy.VKMessagerUWP.VK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Methods
{
    public static class Groups
    {
        public async static Task<List<Group>> Get(List<long> ids, string group_id = "", string fields = "")
        {
            string Gids = string.Empty;
            ids.ForEach((u) => Gids += $"{u},");

            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                ["group_ids"] = Gids,
                ["group_id"] = group_id,
                ["fields"] = fields
            };

            var result = await Call<List<Group>>.Method("groups.getById", param);
            return result;
        }

        public async static Task<List<Group>> Get(List<string> ids, string group_id = "", string fields = "")
        {
            string Gids = string.Empty;
            ids.ForEach((u) => Gids += $"{u},");

            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                ["group_ids"] = Gids,
                ["group_id"] = group_id,
                ["fields"] = fields
            };

            var result = await Call<List<Group>>.Method("groups.getById", param);
            return result;
        }
    }
}
