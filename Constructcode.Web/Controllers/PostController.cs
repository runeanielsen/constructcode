using AutoMapper;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Controllers.ViewModels;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Constructcode.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(ICategoryService categoryService, IPostService postService, IMapper mapper)
        {
            _categoryService = categoryService;
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Post/{url}")]
        [ResponseCache(Duration = 60)]
        public IActionResult Index(string url)
        {
            ViewBag.AngularModule = "app";
            ViewBag.ShowFooter = true;
            return View(_mapper.Map<PostViewModel>(_postService.GetPostOnUrl(url)));
        }

        [HttpGet]
        [Route("Post/Category/{categoryUrl}")]
        [ResponseCache(Duration = 60)]
        public IActionResult Category(string categoryUrl)
        {
            ViewBag.AngularModule = "app";
            ViewBag.ShowFooter = true;
            ViewBag.Title = _categoryService.GetCategoryOnUrl(categoryUrl).Title;

            return View(_mapper.Map<IEnumerable<PostViewModel>>(_postService.GetAllPostsOnCategory(categoryUrl)));
        }
    }
}
