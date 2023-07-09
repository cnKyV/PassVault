using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault.Models
{
    internal class Credentials
    {
        public HashResponse MasterUsername { get; set; }
        public HashResponse MasterPassword { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
