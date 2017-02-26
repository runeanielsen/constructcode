using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers.Admin
{
    [Authorize]
    public class PostController : Controller
    {
        private const string ViewPath = "/Views/Admin/Post";

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View($"{ViewPath}/CreatePost.cshtml");
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            return View($"{ViewPath}/EditPost.cshtml");
        }
    }
}