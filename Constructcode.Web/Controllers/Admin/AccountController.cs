using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers.Admin
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Manage()
        {
            return View();
        }
    }
}
