using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Common.Netcore
{
    public static class Security
    {
        public static byte[] GenerateSalt(int size)
        {
            var salt = new byte[size];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static string GetSaltedHash(string password)
        {
            // Generate a salt
            var salt = GenerateSalt(256); // 32 bytes = 256 bits

            // Compute the hash
            var hash = ComputeHash(password, salt);

            // Combine salt and hash for storage
            var saltedHash = new byte[salt.Length + hash.Length];
            Buffer.BlockCopy(salt, 0, saltedHash, 0, salt.Length);
            Buffer.BlockCopy(hash, 0, saltedHash, salt.Length, hash.Length);

            // Return as a base64 string
            return Convert.ToBase64String(saltedHash);
        }

        public static byte[] ComputeHash(string password, byte[] salt)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var saltedPassword = Encoding.UTF8.GetBytes(password);
                var saltedPasswordWithSalt = new byte[saltedPassword.Length + salt.Length];

                Buffer.BlockCopy(saltedPassword, 0, saltedPasswordWithSalt, 0, saltedPassword.Length);
                Buffer.BlockCopy(salt, 0, saltedPasswordWithSalt, saltedPassword.Length, salt.Length);

                return sha256.ComputeHash(saltedPasswordWithSalt);
            }
        }
    }
}
