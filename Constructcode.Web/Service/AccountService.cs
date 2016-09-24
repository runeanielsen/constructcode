
using Constructcode.Web.Core;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service.Helpers;

namespace Constructcode.Web.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool VerifyAccountLogin(Account account, string plainPassword)
        {
            var hashedPassword = Cryptography.CreateHashedPassword(plainPassword, Cryptography.GetSaltAsByteArray(account.Salt));

            return hashedPassword == account.Password;
        }

        public Account CreateAccount(Account account)
        {
            var salt = Cryptography.CreateSalt();

            account.Password = Cryptography.CreateHashedPassword(account.Password, salt);
            account.Salt = Cryptography.GetSaltAsString(salt);

            _unitOfWork.Accounts.Add(account);
            _unitOfWork.Complete();

            return account;
        }

        public Account GetAccount(string username)
        {
            return _unitOfWork.Accounts.SingleOrDefault(a => a.Username == username);
        }
    }
}