using Constructcode.Web.Core;
using Constructcode.Web.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ConstructCode.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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