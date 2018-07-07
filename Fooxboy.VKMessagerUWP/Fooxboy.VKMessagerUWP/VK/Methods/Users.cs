using Fooxboy.VKMessagerUWP.VK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Methods
{
    public static class Users
    {
        public async static Task<List<User>> Get(List<long> ids, string fields = "", string name_case = "nom")
        {
            string Uids = string.Empty;
            ids.ForEach((u) => Uids += $"{u},");         
            Dictionary<string, string> parametrs = new Dictionary<string, string>()
            {
                ["user_ids"] = Uids,
                ["fields"] = fields,
                ["name_case"] = name_case
            };
            var result = await Call<List<User>>.Method("users.get", parametrs);
            return result;
        }

        public async static Task<User> Me(string fields = "", string name_case = "nom")
        {
            Dictionary<string, string> parametrs = new Dictionary<string, string>()
            {
                ["user_ids"] = "",
                ["fields"] = fields,
                ["name_case"] = name_case
            };
            var result = await Call<List<User>>.Method("users.get", parametrs);


            return result[0];
        }

    }  
}

