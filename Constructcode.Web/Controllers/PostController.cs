using AutoMapper;
using Constructcode.Web.Controllers.ViewModels;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

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
        [ResponseCache(Duration = 120)]
        public IActionResult Index(string url)
        {
            return View(_mapper.Map<PostViewModel>(_postService.GetPostOnUrl(url)));
        }

        [HttpGet]
        [Route("Post/Category/{categoryUrl}")]
        [ResponseCache(Duration = 120)]
        public IActionResult Category(string categoryUrl)
        {
            ViewBag.Title = _categoryService.GetCategoryOnUrl(categoryUrl).Title;

            var displayPostsViewModel = new DisplayPostsViewModel(_postService.GetMaxPageCount(categoryUrl), 1)
            {
                CategoryName = categoryUrl
            };

            displayPostsViewModel.Posts = _mapper.Map<IEnumerable<PostViewModel>>(_postService.GetPostsOnPageNumber(displayPostsViewModel.CurrentPageNumber, categoryUrl));

            return View(displayPostsViewModel);
        }

        [HttpGet]
        [Route("Post/Category/{categoryUrl}/page/{pageNumber}")]
        [ResponseCache(Duration = 120)]
        public IActionResult Category(string categoryUrl, int pageNumber)
        {
            ViewBag.Title = _categoryService.GetCategoryOnUrl(categoryUrl).Title;

            var displayPostsViewModel = new DisplayPostsViewModel(_postService.GetMaxPageCount(categoryUrl), pageNumber)
            {
                CategoryName = categoryUrl
            };

            displayPostsViewModel.Posts =
                _mapper.Map<IEnumerable<PostViewModel>>(_postService.GetPostsOnPageNumber(displayPostsViewModel.CurrentPageNumber, categoryUrl));

            return View(displayPostsViewModel);
        }

        [HttpGet]
        [Route("Post/Page/{pageNumber}")]
        [ResponseCache(Duration = 120)]
        public IActionResult Page(int pageNumber)
        {
            ViewBag.Title = $"Page {pageNumber}";

            var displayPostsViewModel = new DisplayPostsViewModel(_postService.GetMaxPageCount(), pageNumber);
            displayPostsViewModel.Posts =
                _mapper.Map<IEnumerable<PostViewModel>>(_postService.GetPostsOnPageNumber(displayPostsViewModel.CurrentPageNumber));

            return View(displayPostsViewModel);
        }

        [HttpGet]
        [Authorize]
        [Route("Post/Preview/{id}")]
        public IActionResult Preview(int id)
        {
            return View(_mapper.Map<PostViewModel>(_postService.GetPost(id)));
        }
    }
}
