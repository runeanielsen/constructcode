using Microsoft.AspNetCore.Mvc;

namespace ConstructCode.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ShowFooter = true;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}