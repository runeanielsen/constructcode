using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers.Admin
{
    public class AccountController : Controller
    {
        public IActionResult Manage()
        {
            return View();
        }
    }
}
