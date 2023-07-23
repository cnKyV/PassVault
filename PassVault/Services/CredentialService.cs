﻿using System;
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

        public static bool Login(string username, string password)
        {
            HasLoggedIn = true;
            Username = username;
            Password = password;

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
    }
    }

