using System.Security.Claims;
using System.Threading.Tasks;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers
{
    public class AccountController : Controller
    {
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
            if (ModelState.IsValid)
            {
                var claims = new[] { new Claim("name", vm.Username), new Claim(ClaimTypes.Role, "Admin") };
                var claim = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                await HttpContext.Authentication.SignInAsync("CookieMiddlewareInstance", claim);

                return RedirectToAction("Index", "Admin");
            }

            return View("UnAuthorized", vm);
        }
    }
}