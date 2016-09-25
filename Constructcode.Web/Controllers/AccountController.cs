using System.Security.Claims;
using System.Threading.Tasks;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult UnAuthorized()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid) return View("UnAuthorized", vm);

            var account = _accountService.GetAccount(vm.Username);

            if (account == null || !_accountService.VerifyAccountLogin(account, vm.Password))
            {
                ViewBag.ErrorMessage = "Failed to login";
                return View("UnAuthorized", vm);
            }

            var claims = new[] { new Claim("name", account.Username), new Claim(ClaimTypes.Role, "Admin") };
            var claim = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            await HttpContext.Authentication.SignInAsync("CookieMiddlewareInstance", claim);

            return RedirectToAction("Index", "Admin");
        }
    }
}