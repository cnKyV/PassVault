using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PassVault.Services
{
    internal static class CredentialService
    {
        private static bool _hasLoggedin = false;
        private static char[] _userName = new char[char.MinValue];
        private static char[] _password = new char[char.MinValue];

        public static bool Login(string username, string password)
        {
            _hasLoggedin = true;
            _userName = username.ToCharArray();
            _password = password.ToCharArray();

            var path = Configs.Path.DocumentsFullPath(username);

            if (!File.Exists(path))
                throw new FileNotFoundException("Settings not found!");

            var credentials = FileService.GetFile(path);

            if (credentials == null)
                throw new JsonException("Json file is null.");

            var checkUsername = HashingService.VerifyString(username, credentials.MasterUsername);

            if (!checkUsername)
                throw new UnauthorizedAccessException("The credentials you have provided does not match with the Json file.");

            var checkPassword = HashingService.VerifyString(password, credentials.MasterPassword);

            if (!checkPassword)
                throw new UnauthorizedAccessException("The credentials you have provided does not match with the Json file.");

            return true;
        }
    }
}

