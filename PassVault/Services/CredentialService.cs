﻿using PassVault.Models;
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
        public static bool HasLoggedIn = false;
        public static string? Username = null;
        public static string? Password = null;
        public static HashResponse? UsernameHashed = null;
        public static HashResponse? PasswordHashed = null;
        public static List<Account> Accounts = new List<Account>();
        public static List<Account> AccountsEncrypted = new List<Account>();
        public static string EncryptionPassword = string.Empty;



        public static bool Login(string username, string password)
        {
            var path = Configs.Path.DocumentsFullPath(username);

            if (!File.Exists(path))
                return false;

            var credentials = FileService.GetFile(path);

            if (credentials == null)
                return false;

            var checkUsername = HashingService.VerifyString(username, credentials.MasterUsername);

            if (!checkUsername)
                return false;

            var checkPassword = HashingService.VerifyString(password, credentials.MasterPassword);

            if (!checkPassword)
                return false;

            HasLoggedIn = true;
            
            Username = username;
            Password = password;

            EncryptionPassword = GenerateEncryptionPassword(username, password);

            UsernameHashed = credentials.MasterUsername;
            PasswordHashed = credentials.MasterPassword;

            AccountsEncrypted = credentials.Accounts.ToList();

            if(AccountsEncrypted.Any())
            foreach (var account in AccountsEncrypted)
            {
                var acc = new Account();

                acc.Username = EncryptionService.SimpleDecryptWithPassword(account.Username, EncryptionPassword);
                acc.Password = EncryptionService.SimpleDecryptWithPassword(account.Password, EncryptionPassword);
                acc.Email = EncryptionService.SimpleDecryptWithPassword(account.Email, EncryptionPassword);
                acc.Alias = EncryptionService.SimpleDecryptWithPassword(account.Alias, EncryptionPassword);
                acc.Link = EncryptionService.SimpleDecryptWithPassword(account.Link, EncryptionPassword);

                Accounts.Add(acc);
            }


            return true;
        }

        public static bool ValidateLogin(string username, string password)
        {
            if (HasLoggedIn && Username == username && Password == password)
                return true;

            return false;
        }

        public static void ChangeMasterPassword(string username, string oldPassword, string newPassword)
        {
            if (!ValidateLogin(username, oldPassword))
                throw new InvalidOperationException("Credentials don't match with the logged-in user.");

            if(oldPassword == newPassword) return;

            Password = newPassword;
        }

        public static void Logoff()
        {
            HasLoggedIn = false;
            Username = null;
            Password = null;
        }

        private static string GenerateEncryptionPassword(string username, string password)
        {
            var result = username + password;

            return result;  
        }
    }
    }

