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
        private static bool _hasLoggedin = false;
        private static string? _userName = null;
        private static string? _password = null;

        public static bool Login(string username, string password)
        {
            _hasLoggedin = true;
            _userName = username;
            _password = password;

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
            if (_hasLoggedin && _userName == username && _password == password)
                return true;

            return false;
        }

        public static void ChangeMasterPassword(string username, string oldPassword, string newPassword)
        {
            if (!ValidateLogin(username, oldPassword))
                throw new InvalidOperationException("Credentials don't match with the logged-in user.");

            if(oldPassword == newPassword) return;

            _password = newPassword;
        }

        public static void Logoff()
        {
            _hasLoggedin = false;
            _userName = null;
            _password = null;
        }
    }
    }

