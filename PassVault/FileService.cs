using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PassVault
{
    internal static class FileService
    {
        public static void CreateJson(string path, string masterName, string masterPassword)
        {
            var jsonName = Path.DocumentsFullPath(masterName);

            if (File.Exists(jsonName))
                File.Delete(jsonName);

            var creds = new Creds();

            creds.MasterUname = masterName;
            creds.MasterPass = masterPassword;
            creds.Accounts = new List<Account>();

            CryptoService.Encrypt(creds);

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
