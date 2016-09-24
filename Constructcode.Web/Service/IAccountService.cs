using System.Threading.Tasks;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ViewModels;

namespace Constructcode.Web.Service
{
    public interface IAccountService
    {
        Account CreateAccount(Account account);
        bool VerifyAccountLogin(Account account, string plainPasword);
        Account GetAccount(string username);
    }
}
