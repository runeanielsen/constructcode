using Constructcode.Web.Core;
using Microsoft.AspNetCore.Mvc;

namespace ConstructCode.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _context;

        public HomeController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}