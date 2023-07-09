using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault.Models
{
    internal class Account
    {

        public int Id { get; set; }
        public HashResponse Username { get; set; }
        public HashResponse Password { get; set; }
        public HashResponse Email { get; set; }
        public HashResponse Link { get; set; }
    }
}
