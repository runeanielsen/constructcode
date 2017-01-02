using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers.Admin
{
    [Authorize]
    public class PostController : Controller
    {
        private const string _viewPath = "/Views/Admin/Post";

        [HttpGet]
        public IActionResult CreatePost()
        {
            ViewBag.AngularModule = "managePosts";
            return View($"{_viewPath}/CreatePost.cshtml");
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            ViewBag.AngularModule = "managePosts";
            return View($"{_viewPath}/EditPost.cshtml");
        }
    }
}