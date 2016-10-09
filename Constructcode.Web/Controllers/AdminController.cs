using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Constructcode.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public AdminController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
            return View(_blogPostService.GetAllBlogPosts().OrderBy(a => a.Created));
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel vm)
        {
            _blogPostService.Save(new Post
            {
                Title = vm.Title,
                Content = vm.Content
            });

            return View("Index");
        }
    }
}