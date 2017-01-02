using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers.Admin
{
    [Authorize]
    public class AccountController : Controller
    {
        private const string _viewPath = "/Views/Admin/Account";

        public IActionResult Manage()
        {
            ViewBag.AngularModule = "app";
            return View($"{_viewPath}/Manage.cshtml");
        }

        public IActionResult Settings()
        {
            ViewBag.AngularModule = "app";
            return View($"{_viewPath}/Settings.cshtml");
        }
    }
}
