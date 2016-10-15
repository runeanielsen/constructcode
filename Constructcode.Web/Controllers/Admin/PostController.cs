using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers.Admin
{
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View(new CreatePostViewModel());
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel vm)
        {
            _postService.Save(_mapper.Map<Post>(vm));

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            return View(_mapper.Map<EditPostViewModel>(_postService.GetBlogPost(id)));
        }

        [HttpPost]
        public IActionResult EditPost(EditPostViewModel vm)
        {
            _postService.UpdatePost(_mapper.Map<Post>(vm));

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult DeletePost(int id)
        {
            _postService.DeletePost(id);

            return RedirectToAction("Index", "Admin");
        }
    }
}