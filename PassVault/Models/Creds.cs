using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassVault.Models;

namespace PassVault
{
    internal class Creds
    {
        public string MasterUname { get; set; }
        public string MasterPass { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
