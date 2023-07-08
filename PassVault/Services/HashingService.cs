using PassVault.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassVault.Services
{
    internal static class HashingService
    {
        public static readonly int KeyBitSize = 256;
        public static readonly int Iteration = 350000;
        public static readonly HashAlgorithmName HashAlgorithmType = HashAlgorithmName.SHA512;

        internal static HashResponse HashPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            var salt = RandomNumberGenerator.GetBytes(KeyBitSize / 8);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                Iteration,
                HashAlgorithmType,
                KeyBitSize / 8
                );

            var hashResponse = new HashResponse();

            hashResponse.Salt = Encoding.UTF8.GetString(salt);
            hashResponse.HashedPassword = Convert.ToHexString(hash);

            return hashResponse;
        }

        internal static bool VerifyPassword(string password, HashResponse hashedPassword)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, Encoding.UTF8.GetBytes(hashedPassword.Salt), Iteration, HashAlgorithmType,KeyBitSize/8);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashedPassword.HashedPassword));
        }
    }
}
