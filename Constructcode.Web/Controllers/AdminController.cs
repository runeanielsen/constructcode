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
        private readonly IBlogPostService _blogPostService;
        private readonly IMapper _mapper;

        public AdminController(IBlogPostService blogPostService, IMapper mapper)
        {
            _blogPostService = blogPostService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var blogposts = _blogPostService.GetAllBlogPosts().OrderByDescending(a => a.Created);

            return View(_mapper.Map<IEnumerable<PostViewModel>>(blogposts));
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel vm)
        {
            _blogPostService.Save(_mapper.Map<Post>(vm));

            return RedirectToAction("Index");
        }
    }
}