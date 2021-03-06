﻿using AutoMapper;
using Constructcode.Web.Controllers.ViewModels;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConstructCode.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public HomeController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [ResponseCache(Duration = 120)]
        public IActionResult Index()
        {
            var displayPostsViewModel = new DisplayPostsViewModel(_postService.GetMaxPageCount(), 1);

            displayPostsViewModel.Posts =
                _mapper.Map<IEnumerable<PostViewModel>>(_postService.GetPostsOnPageNumber(displayPostsViewModel.CurrentPageNumber));

            return View(displayPostsViewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}