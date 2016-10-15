using System.Collections.Generic;
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
    }
}