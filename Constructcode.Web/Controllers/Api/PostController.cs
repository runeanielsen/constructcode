using System.Collections.Generic;
using AutoMapper;
using Constructcode.Web.Service;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Constructcode.Web.Controllers.Api
{
    [Authorize]
    public class PostController : Controller 
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public IActionResult GetAllPosts()
        {
            var blogposts = _postService.GetAllPosts().OrderByDescending(a => a.Created);

            return Ok(_mapper.Map<IEnumerable<PostViewModel>>(blogposts));
        }
    }
}
