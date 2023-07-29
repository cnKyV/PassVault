using PassVault.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PassVault.Models
{
    internal class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }
        public string Alias { get; set; }   
    }
}
