using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                return BadRequest("Bad Password or Login");
            }

            var claims = new[] { new Claim("name", account.Username), new Claim(ClaimTypes.Role, "Admin") };
            var claim = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            await HttpContext.Authentication.SignInAsync("CookieMiddlewareInstance", claim);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("CookieMiddlewareInstance");
            return Ok();
        }
    }
}
