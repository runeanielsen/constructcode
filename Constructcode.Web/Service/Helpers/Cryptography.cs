using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Constructcode.Web.Service.Helpers
{
    public static class Cryptography
    {
        public static string CreateHashedPassword(string password, byte[] salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256, 
                1000000,
                32));

            return hashed;
        }

        public static byte[] CreateSalt()
        {
            var salt = new byte[16];

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
