using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Constructcode.Web.Service.Helpers
{
    public class Cryptography
    {
        public static string CreateHashedPassword(string password, byte[] salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA1,
                10000,
                256/8));

            return hashed;
        }

        public static byte[] CreateSalt()
        {
            var salt = new byte[128/8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public static string GetSaltAsString(byte[] salt)
        {
            return Convert.ToBase64String(salt);
        }

        public static byte[] GetSaltAsByteArray(string salt)
        {
            return Convert.FromBase64String(salt);
        }
    }
}
