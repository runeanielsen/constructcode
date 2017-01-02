using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult UnAuthorized()
        {
            ViewBag.AngularModule = "app";
            return View();
        }

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}