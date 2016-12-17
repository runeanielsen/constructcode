using AutoMapper;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Constructcode.Web.ApiControllers.Api
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
        public IActionResult GetAllPublishedPosts()
        {
            var blogposts = _postService.GetAllPosts().Where(a => a.Published).OrderByDescending(a => a.Created);

            return Ok(_mapper.Map<IEnumerable<PostDto>>(blogposts));
        }

        [HttpGet]
        public IActionResult GetAllPostsOnCategory(string id)
        {
            var blogposts = _postService.GetAllPostsOnCategory(id).Where(a => a.Published).OrderByDescending(a => a.Created);

            return Ok(_mapper.Map<IEnumerable<PostDto>>(blogposts));
        }

        [HttpGet]
        public IActionResult GetPost(int id)
        {
            var blogPost = _postService.GetPost(id);

            return Ok(_mapper.Map<PostDto>(blogPost));
        }

        [HttpGet]
        public IActionResult GetPostOnUrl(string id)
        {
            return Ok(_mapper.Map<PostDto>(_postService.GetPostOnUrl(id)));
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var blogposts = _postService.GetAllPosts().OrderByDescending(a => a.Created);

            return Ok(_mapper.Map<IEnumerable<PostDto>>(blogposts));
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

            return Ok($"/images/{file.FileName}");
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePost([FromBody]CreatePostDto vm)
        {
            var mappedPost = _mapper.Map<Post>(vm);

            var validation = _postService.ValidatePost(mappedPost);
            if (!validation.IsValid)
                return BadRequest(validation.Message);

            _postService.CreatePost(mappedPost);

            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdatePost([FromBody]EditPostDto vm)
        {
            var mappedPost = _mapper.Map<Post>(vm);

            var validation = _postService.ValidatePost(mappedPost);
            if (!validation.IsValid)
                return StatusCode(validation.StatusCodeAsIntegar, validation.Message);

            _postService.UpdatePost(mappedPost);

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