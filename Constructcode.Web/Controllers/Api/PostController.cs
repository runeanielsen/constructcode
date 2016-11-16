using System.Collections.Generic;
using AutoMapper;
using Constructcode.Web.Service;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Constructcode.Web.Core.Domain;

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

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var blogposts = _postService.GetAllPosts().OrderByDescending(a => a.Created);

            return Ok(_mapper.Map<IEnumerable<PostViewModel>>(blogposts));
        }

        [HttpGet]
        public IActionResult GetPost(int id)
        {
            var blogPost = _postService.GetBlogPost(id);

            return Ok(_mapper.Map<EditPostViewModel>(blogPost));
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody]CreatePostViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _postService.CreatePost(_mapper.Map<Post>(vm));

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdatePost([FromBody]EditPostViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _postService.UpdatePost(_mapper.Map<Post>(vm));

            return Ok();
        }
    }
}