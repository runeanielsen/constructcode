using System.Collections.Generic;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;

namespace Constructcode.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public AdminController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var blogposts = _postService.GetAllPosts().OrderByDescending(a => a.Created);

            return View(_mapper.Map<IEnumerable<PostViewModel>>(blogposts));
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

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }
    }
}