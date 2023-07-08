using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault.Models
{
    internal class HashResponse
    {
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}
