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
        private string _username;
        private string _password;
        private string _email;
        private string _link;
        private string _alias;
        public string Username { 
            get 
            {
                return EncryptionService.SimpleDecryptWithPassword(_username, CredentialService.Username + CredentialService.Password, new byte[10110]);
            }
            set 
            {
                _username = EncryptionService.SimpleEncryptWithPassword(value, CredentialService.Username + CredentialService.Password);
            }
        }
        public string Password
        {
            get
            {
                return EncryptionService.SimpleDecryptWithPassword(_password, CredentialService.Username + CredentialService.Password);
            }
            set
            {
                _password = EncryptionService.SimpleEncryptWithPassword(value, CredentialService.Username + CredentialService.Password);
            }
        }
        public string Email
        {
            get
            {
                return EncryptionService.SimpleDecryptWithPassword(_email, CredentialService.Username + CredentialService.Password);
            }
            set
            {
                _email = EncryptionService.SimpleEncryptWithPassword(value, CredentialService.Username + CredentialService.Password);
            }
        }
        public string Link
        {
            get
            {
                return EncryptionService.SimpleDecryptWithPassword(_link, CredentialService.Username + CredentialService.Password);
            }
            set
            {
                _link = EncryptionService.SimpleEncryptWithPassword(value, CredentialService.Username + CredentialService.Password);
            }
        }
        public string Alias
        {
            get
            {
                return EncryptionService.SimpleDecryptWithPassword(_alias, CredentialService.Username + CredentialService.Password);
            }
            set
            {
                _alias = EncryptionService.SimpleEncryptWithPassword(value, CredentialService.Username + CredentialService.Password);
            }
        }
    }
}
