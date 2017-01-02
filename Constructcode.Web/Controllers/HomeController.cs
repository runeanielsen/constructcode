using AutoMapper;
using Constructcode.Web.ApiControllers.DataTransferObjects;
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
        [ResponseCache(Duration = 60)]
        public IActionResult Index()
        {
            ViewBag.AngularModule = "app";
            ViewBag.ShowFooter = true;
            
            return View(_mapper.Map<IEnumerable<PostDto>>(_postService.GetAllPublishedPosts()));
        }

        public IActionResult Error()
        {
            ViewBag.AngularModule = "app";
            return View();
        }
    }
}