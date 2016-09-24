using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Service
{
    public interface IAccountService
    {
        Account CreateAccount(Account account);
        Account VerifyAccount(Account account);
    }
}
