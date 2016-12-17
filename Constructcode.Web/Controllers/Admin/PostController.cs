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
            return View($"{_viewPath}/CreatePost.cshtml");
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            return View($"{_viewPath}/EditPost.cshtml");
        }
    }
}