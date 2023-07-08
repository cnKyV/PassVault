using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PassVault.Models;

namespace PassVault.Services
{
    internal static class FileService
    {
        public static void CreateJson(string masterName, string masterPassword)
        {
            var jsonName = Path.DocumentsFullPath(masterName);
            var secretMessage = string.Empty;
            var nonSecretPayload = string.Empty;


            if (File.Exists(jsonName))
                File.Delete(jsonName);

            var creds = new Creds();

            creds.MasterUname = masterName;
            creds.MasterPass = masterPassword;
            creds.Accounts = new List<Account>();

#if DEBUG
            var preloadValues = Path.DemoValues;
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
                var cryptoService = EncryptionService.SimpleEncryptWithPassword(secretMessage, masterPassword);


            }



            var initialJson = JsonSerializer.Serialize(creds);


            File.Create(jsonName);

            if (!File.Exists(jsonName))
                throw new FileNotFoundException("Couldn't create the file.");
        }
        public static void UpdateJson(string path, Creds creds)
        {

        }
        public static void GetJson(string path)
        {

        }
    }

}
