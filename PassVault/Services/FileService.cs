using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PassVault.Configs;
using PassVault.Models;

namespace PassVault.Services
{
    

    internal static class FileService
    {
        private static bool _hasLoggedin = false;
        private static char[] _userName = new char[char.MinValue];
        private static char[] _password = new char[char.MinValue];

        public static void CreateFile(string masterName, string masterPassword)
        {
            _userName = masterName.ToCharArray();
            _password = masterPassword.ToCharArray();

            var jsonName = Configs.Path.DocumentsFullPath(masterName);
            var secretMessage = string.Empty;
            var nonSecretPayload = string.Empty;



#if DEBUG
            var preloadValues = Configs.Path.DemoValues;
            if (File.Exists(preloadValues))
            {
                var values = File.ReadAllText(preloadValues);
                var convertedValues = JsonSerializer.Deserialize<PreloadValue>(values);

                secretMessage = convertedValues.CryptoConfig.SECRET_MESSAGE;
                nonSecretPayload = convertedValues.CryptoConfig.NON_SECRET_PAYLOAD;
            }
#endif

            if (!string.IsNullOrEmpty(secretMessage) && !string.IsNullOrEmpty(nonSecretPayload))
            {
                var payloadInBytes = Encoding.UTF8.GetBytes(secretMessage);
                var encryptedPass = EncryptionService.SimpleEncryptWithPassword(secretMessage, masterPassword);
                var creds = new Credentials();

                creds.MasterUsername = HashingService.HashString(masterName);
                creds.MasterPassword = HashingService.HashString(masterPassword);

                var initialJson = JsonSerializer.Serialize(creds);

               File.WriteAllText(jsonName, initialJson);
            }

            if (!File.Exists(jsonName))
                throw new FileNotFoundException("Couldn't create the file.");
        }
        public static void UpdateFile(string path, Credentials creds)
        {

        }
        public static Credentials GetFile(string path)
        {
            if (File.Exists(path))
            {
                var fileAsString = File.ReadAllText(path);
                var asJson = JsonSerializer.Deserialize<Credentials>(fileAsString);

                if (asJson != null)
                return asJson;

                throw new JsonException("Ill Json Format!");
            }
            throw new FileNotFoundException("Settings not found.");
        }
    }

}
