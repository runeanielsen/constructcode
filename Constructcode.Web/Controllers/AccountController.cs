using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult UnAuthorized()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}