using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Constructcode.Web.ApiControllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto vm)
        {
            var account = _accountService.GetAccount(vm.Username);

            if (account == null || !_accountService.VerifyAccountLogin(account, vm.Password))
            {
                return BadRequest("Bad Username or Password");
            }

            await HttpContext.Authentication.SignInAsync("CookieMiddlewareInstance", _accountService.CreateAuthenticationClaim(account));
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("CookieMiddlewareInstance");
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsername()
        {
            var authenticationInfo = HttpContext;
            return Ok();
        }
    }
}
