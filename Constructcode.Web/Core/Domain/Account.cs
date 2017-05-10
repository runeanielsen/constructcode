using Constructcode.Web.Service.Helpers;

namespace Constructcode.Web.Core.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public void UpdatePassword()
        {
            var salt = Cryptography.CreateSalt();
            Password = Cryptography.CreateHashedPassword(Password, salt);
            Salt = Cryptography.GetSaltAsString(salt);
        }

        public bool VerifyAuthentication(string plainTextPassword)
        {
            return Cryptography.CreateHashedPassword(plainTextPassword, Cryptography.GetSaltAsByteArray(Salt)) == Password;
        }
    }
}
