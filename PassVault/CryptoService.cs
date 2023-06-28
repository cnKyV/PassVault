using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassVault
{
    internal static class CryptoService
    {
        //AES then HMAC

        private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();

        public static readonly int BlockBitSize = 128;
        public static readonly int KeyBitSize = 256;
        
        public static readonly int SaltBitSize = 64;
        public static readonly int Iteration = 10000;
        public static readonly int MinPasswordLength = 12;

        public static byte[] NewKey()
        {
            var key = new byte[KeyBitSize / 8];
            Random.GetBytes(key); 
            return key;
        }
      
        public static string SimpleEncrypt(string secretMessage, byte[] cryptKey, byte[] authKey, byte[] nonSecretPayload = null)
        {
            if (string.IsNullOrEmpty(secretMessage))
                throw new ArgumentException("Secret Message Required!", "secretMessage");

            var plainText = Encoding.UTF8.GetBytes(secretMessage);
            var cipherText = SimpleEncrypt(plainText,cryptKey, authKey, nonSecretPayload);
            return Convert.ToBase64String(cipherText);
        }   

        public static string SimpleDecrypt(string encryptedMessage, byte[] cryptKey, byte[] authKey, int nonSecretPayloadLength = 0)
        {
            if (string.IsNullOrWhiteSpace(encryptedMessage))
                throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

            var cipherText = Convert.FromBase64String(encryptedMessage);
            var plainText = SimpleDecrypt(cipherText,cryptKey,authKey, nonSecretPayloadLength);
            return plainText == null ? "" : Encoding.UTF8.GetString(plainText);
        }

        public static string SimpleEncryptWithPassword(string secretMessage, string password, byte[] nonSecretPayload = null)
        {
            if (string.IsNullOrEmpty(secretMessage))
                throw new ArgumentException("Secret Message Required!", "secretMessage");

            var plainText = Encoding.UTF8.GetBytes(secretMessage);
            var cipherText = SimpleEncryptWithPassword(plainText, password, nonSecretPayload);
            return Convert.ToBase64String(cipherText);
        }

        public static string SimpleDecryptWithPassword(string encryptedMessage, string password, int nonSecretPayloadLength = 0)
        {
            if (string.IsNullOrWhiteSpace(encryptedMessage))
                throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

            var cipherText = Convert.FromBase64String(encryptedMessage);
            var plainText = SimpleDecryptWithPassword(cipherText, password, nonSecretPayloadLength);
            return plainText == null ? null : Encoding.UTF8.GetString(plainText);
        }

        public static byte[] SimpleEncrypt(byte[] secretMessage, byte[] cryptKey, byte[] authKey, byte[] nonSecretPayload = null)
        {
            if (cryptKey == null || cryptKey.Length != KeyBitSize / 8)
                throw new ArgumentNullException($"Key needs to be {KeyBitSize} bit.");

            if (authKey == null || authKey.Length != KeyBitSize / 8)
                throw new ArgumentNullException($"Key needs to be {KeyBitSize} bit.");
            
            if(secretMessage == null || secretMessage.Length != KeyBitSize / 8)
                throw new ArgumentNullException($"Secret Message Required!");

            nonSecretPayload = nonSecretPayload ?? new byte[] { };

            byte[] cipherText;
            byte[] iv;

            using (var aes = new AesManaged
            {
                KeySize = KeyBitSize,
                BlockSize = BlockBitSize,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            {
                aes.GenerateIV();
                iv = aes.IV;

                using(var encrypter = aes.CreateEncryptor(cryptKey, iv))
                using(var cipherStream = new MemoryStream())
                {
                    using(var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                    using(var binaryWriter = new BinaryWriter(cryptoStream))
                    {
                        binaryWriter.Write(secretMessage);
                    }

                    cipherText = cipherStream.ToArray();
                }
            }

            using(var hmac = new HMACSHA256(authKey))
            using(var encryptedStream = new MemoryStream())
            {
                using(var binaryWriter = new BinaryWriter(encryptedStream))
                {
                    binaryWriter.Write(nonSecretPayload);
                    binaryWriter.Write(iv);
                    binaryWriter.Write(cipherText);
                    binaryWriter.Flush();

                    var tag = hmac.ComputeHash(encryptedStream.ToArray());
                    binaryWriter.Write(tag);
                }
                return encryptedStream.ToArray();

            }
        }

        public static byte[] SimpleDecrypt(byte[] encryptedMessage, byte[] cryptKey, byte[] authKey, int nonSecretPayloadLength = 0)
        {
            if (cryptKey == null || cryptKey.Length != KeyBitSize / 8)
                throw new ArgumentException(String.Format("CryptKey needs to be {0} bit!", KeyBitSize), "cryptKey");

            if (authKey == null || authKey.Length != KeyBitSize / 8)
                throw new ArgumentException(String.Format("AuthKey needs to be {0} bit!", KeyBitSize), "authKey");

            if (encryptedMessage == null || encryptedMessage.Length == 0)
                throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

            using(var hmac = new HMACSHA256(authKey))
            {
                var sentTag = new byte[hmac.HashSize / 8];
                
                var calcTag = hmac.ComputeHash(encryptedMessage, 0, encryptedMessage.Length - sentTag.Length);
                var ivLength = (BlockBitSize / 8);

                if (encryptedMessage.Length < sentTag.Length + nonSecretPayloadLength + ivLength)
                    return null;

                Array.Copy(encryptedMessage, encryptedMessage.Length - sentTag.Length, sentTag, 0, sentTag.Length);

                var compare = 0;

                for (var i = 0; i < sentTag.Length; i++)
                    compare |= sentTag[i] ^ calcTag[i];

                if (compare != 0)
                    return null;

                using(var aes = new AesManaged
                {
                    KeySize = KeyBitSize,
                    BlockSize = BlockBitSize,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                {
                    var iv = new byte[ivLength];
                    Array.Copy(encryptedMessage, nonSecretPayloadLength, iv, 0, ivLength);

                    using(var decrypter = aes.CreateDecryptor(cryptKey, iv))
                    using(var plainTextStream = new MemoryStream())
                    {
                        using(var decrypterStream = new CryptoStream(plainTextStream, decrypter, CryptoStreamMode.Write))
                        using(var binaryWriter = new BinaryWriter(decrypterStream))
                        {
                            binaryWriter.Write(
                                encryptedMessage,
                                nonSecretPayloadLength + iv.Length,
                                encryptedMessage.Length - nonSecretPayloadLength - iv.Length - sentTag.Length
                                );
                        }
                        return plainTextStream.ToArray();
                    }
                }
            }
        }
        
        public static byte[] SimpleEncryptWithPassword(byte[] secretMessage, string password, byte[] nonSecretPayload = null)
        {
            nonSecretPayload = nonSecretPayload ?? new byte[0];

            if(string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                throw new ArgumentException(String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");

            if(secretMessage ==  null || secretMessage.Length == 0)
                throw new ArgumentException("Secret Message Required!", "secretMessage");

            var payload = new byte[((SaltBitSize / 8) * 2) + nonSecretPayload.Length];

            Array.Copy(nonSecretPayload,payload,nonSecretPayload.Length);
            int payloadIndex = nonSecretPayload.Length;

            byte[] cryptKey;
            byte[] authKey;

            using(var generator = new Rfc2898DeriveBytes(password,SaltBitSize / 8, Iteration))
            {
                var salt = generator.Salt;

                cryptKey = generator.GetBytes(KeyBitSize / 8);

                Array.Copy(salt,0,payload,payloadIndex,salt.Length);
                payloadIndex += salt.Length;
            }

            using(var generator = new Rfc2898DeriveBytes(password, SaltBitSize / 8, Iteration))
            {
                var salt = generator.Salt;

                authKey = generator.GetBytes(KeyBitSize / 8);

                Array.Copy(salt, 0, payload,payloadIndex,salt.Length);
            }

            return SimpleEncrypt(secretMessage, cryptKey, authKey, payload);
        }

        public static byte[] SimpleDecryptWithPassword(byte[] encryptedMessage, string password, int nonSecretPayloadLength = 0)
        {

            if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                throw new ArgumentException(String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");

            if (encryptedMessage == null || encryptedMessage.Length == 0)
                throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

            var cryptSalt = new byte[SaltBitSize / 8];
            var authSalt = new byte[SaltBitSize / 8];

            Array.Copy(encryptedMessage, nonSecretPayloadLength, cryptSalt, 0, cryptSalt.Length);
            Array.Copy(encryptedMessage, nonSecretPayloadLength + cryptSalt.Length, authSalt, 0, authSalt.Length);

            byte[] cryptKey;
            byte[] authKey;

            using(var generator = new Rfc2898DeriveBytes(password, cryptSalt, Iteration))
                cryptKey = generator.GetBytes(KeyBitSize / 8);
            

            using(var generator = new Rfc2898DeriveBytes(password,authSalt,Iteration))
                authKey = generator.GetBytes(KeyBitSize / 8);


            return new byte[] { };
        }
    }
}
