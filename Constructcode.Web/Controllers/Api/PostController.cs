using System.Collections.Generic;
using System.IO;
using AutoMapper;
using Constructcode.Web.Service;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Constructcode.Web.Core.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Constructcode.Web.Controllers.Api
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _environment;

        public PostController(IPostService postService, IMapper mapper, IHostingEnvironment environment)
        {
            _postService = postService;
            _mapper = mapper;
            _environment = environment;
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

            return Ok(_mapper.Map<PostViewModel>(blogPost));
        }

        [HttpGet]
        public IActionResult GetPostOnUrl(string id)
        {
            return Ok(_mapper.Map<PostViewModel>(_postService.GetPostOnUrl(id)));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadPostImage(IFormFile file)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "images");

            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePost([FromBody]CreatePostViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _postService.CreatePost(_mapper.Map<Post>(vm));

            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdatePost([FromBody]EditPostViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _postService.UpdatePost(_mapper.Map<Post>(vm));

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            _postService.DeletePost(id);
            return Ok();
        }
    }
}