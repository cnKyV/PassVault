using PassVault.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassVault.Models
{
    internal class Account
    {
        public Account() { }
        public Account(string username, string password, string email, string link, string alias) 
        {
            Username = HashingService.HashString(username);
            Password = HashingService.HashString(password);
            Email = HashingService.HashString(email);
            Link = HashingService.HashString(link);
            Alias = HashingService.HashString(alias);
        }
        public Account(HashResponse username, HashResponse password, HashResponse email, HashResponse link, HashResponse alias)
        {
            Username = username;
            Password = password;
            Email = email;
            Link = link;
            Alias = alias;
        }


        public HashResponse Username { get; set; }
        public HashResponse Password { get; set; }
        public HashResponse Email { get; set; }
        public HashResponse Link { get; set; }
        public HashResponse Alias { get; set; }
    }
}
