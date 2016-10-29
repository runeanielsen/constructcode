using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers.Admin
{
    [Authorize]
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            ViewBag.PostId = id;
            return View();
        }
    }
}