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
            return View($"{_viewPath}/Manage.cshtml");
        }

        public IActionResult Settings()
        {
            return View($"{_viewPath}/Settings.cshtml");
        }
    }
}
