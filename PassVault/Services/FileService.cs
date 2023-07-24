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

        public async static Task UpsertFile(string masterUsername, string masterPassword, Credentials? credentials = null)
        {
            var filePath = Configs.Path.DocumentsFullPath(masterUsername);


                if (credentials is null && !File.Exists(filePath))
                {
                    credentials = new Credentials();

                    credentials.MasterUsername = HashingService.HashString(masterUsername);
                    credentials.MasterPassword = HashingService.HashString(masterPassword);
                    credentials.Accounts = new List<Account>();
                }

            await using (var ms = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync(ms,credentials);

                ms.Position = 0;
               var json = Encoding.ASCII.GetString(ms.ToArray()); 

                await File.WriteAllTextAsync(filePath, json, Encoding.UTF8);
            }

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Couldn't create the file.");
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
