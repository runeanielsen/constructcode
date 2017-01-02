using Constructcode.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        public PostController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }

        [HttpGet]
        [Route("Post/{url}")]
        [ResponseCache(Duration = 60)]
        public IActionResult Index(string url)
        {
            ViewBag.AngularModule = "app";
            ViewBag.ShowFooter = true;
            ViewBag.Title = _postService.GetPostOnUrl(url).Title;
            return View();
        }

        [HttpGet]
        [Route("Post/Category/{categoryUrl}")]
        [ResponseCache(Duration = 60)]
        public IActionResult Category(string categoryUrl)
        {
            ViewBag.AngularModule = "app";
            ViewBag.ShowFooter = true;
            ViewBag.Title = _categoryService.GetCategoryOnUrl(categoryUrl).Title;
            return View();
        }
    }
}
