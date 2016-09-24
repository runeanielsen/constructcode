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
    }
}