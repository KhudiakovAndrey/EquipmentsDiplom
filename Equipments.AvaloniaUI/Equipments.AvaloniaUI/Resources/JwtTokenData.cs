using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Equipments.AvaloniaUI.Resources
{
    public static class JwtTokenData
    {
        private const string Password = "ccf6a258-15ef-426d-87a5-3eafcc8077e4"; // пароль для шифрования
        private const int SaltSize = 16; // размер соли
        private const int KeySize = 256; // размер ключа
        private const int Iterations = 10000; // количество итераций

        public static string? AccessToken { get; set; }

        public static string EncryptToken(string token)
        {
            using (var aes = new AesManaged())
            {
                var key = new Rfc2898DeriveBytes(Password, SaltSize, Iterations);
                aes.Key = key.GetBytes(KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(token);
                        }
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        public static string DecryptToken(string encryptedToken)
        {
            using (var aes = new AesManaged())
            {
                var key = new Rfc2898DeriveBytes(Password, SaltSize, Iterations);
                aes.Key = key.GetBytes(KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream(Convert.FromBase64String(encryptedToken)))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}

