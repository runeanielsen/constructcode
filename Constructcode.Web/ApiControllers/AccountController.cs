using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Configurations;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

            var authenticationClaim = _accountService.CreateAuthenticationClaim(account);

            await HttpContext.Authentication
                .SignInAsync(AuthenticationMiddlewareConfig.AuthenticationCookieName, authenticationClaim);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync(AuthenticationMiddlewareConfig.AuthenticationCookieName);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAccountName()
        {          
            return Ok(User.FindFirst("name").Value);
        }
    }
}
