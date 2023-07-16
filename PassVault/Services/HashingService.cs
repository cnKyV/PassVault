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
    public static class HashingService
    {
        public static readonly int KeyBitSize = 256;
        public static readonly int Iteration = 350000;
        public static readonly HashAlgorithmName HashAlgorithmType = HashAlgorithmName.SHA512;

        public static HashResponse HashString(string password)
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

            hashResponse.Salt = Convert.ToHexString(salt);
            hashResponse.HashedString = Convert.ToHexString(hash);

            return hashResponse;
        }

        public static bool VerifyString(string password, HashResponse hashedPassword)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, Convert.FromHexString(hashedPassword.Salt), Iteration, HashAlgorithmType,KeyBitSize/8);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashedPassword.HashedString));
        }
    }
}
