using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.Model
{
    public class AccountsList
    {
        public List<Account> Accounts { get; set; }
    }
    public class Account
    {
        public string Token { get; set; }
        public long Id { get; set; }
        public string Pic { get; set; }
        public bool PicIsUrl { get; set; }
        public string Name { get; set; }
    }
}
