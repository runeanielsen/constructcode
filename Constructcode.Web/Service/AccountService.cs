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

        public Account CreateAccount(Account account)
        {
            var salt = Cryptography.CreateSalt();

            account.Password = Cryptography.CreateHashedPassword(account.Password, salt);
            account.Salt = Cryptography.GetSaltAsString(salt);

            _unitOfWork.Accounts.Add(account);

            return account;
        }

        public Account VerifyAccount(Account account)
        {
            throw new System.NotImplementedException();
        }
    }
}
