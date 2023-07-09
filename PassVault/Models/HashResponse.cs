using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault.Models
{
    public class HashResponse
    {
        public string HashedString { get; set; }
        public string Salt { get; set; }
    }
}
