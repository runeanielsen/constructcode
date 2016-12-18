using Constructcode.Web.Core.Domain;
using System.Security.Claims;

namespace Constructcode.Web.Service
{
    public interface IAccountService
    {
        Account CreateAccount(Account account);
        bool VerifyAccountLogin(Account account, string plainPasword);
        Account GetAccount(string username);
        ClaimsPrincipal CreateAuthenticationClaim(Account account);
    }
}