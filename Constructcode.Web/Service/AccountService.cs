using Constructcode.Web.Core;
using Constructcode.Web.Core.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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
            return account.VerifyAuthentication(plainPassword);
        }

        public Account CreateAccount(Account account)
        {
            account.UpdatePassword();

            _unitOfWork.Accounts.Add(account);
            _unitOfWork.Complete();

            return account;
        }

        public Account GetAccount(string username)
        {
            return _unitOfWork.Accounts.SingleOrDefault(a => a.Username == username);
        }

        public ClaimsPrincipal CreateAuthenticationClaim(Account account)
        {
            var claims = new[] {
                new Claim("name", account.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claim = new ClaimsPrincipal(
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            return claim;
        }

        public void UpdateAccount(Account account)
        {
            account.UpdatePassword();

            _unitOfWork.Accounts.Update(account);
            _unitOfWork.Complete();
        }
    }
}