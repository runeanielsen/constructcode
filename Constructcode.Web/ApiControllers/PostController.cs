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
        private readonly ISitemapService _sitemapService;

        public PostController(IPostService postService, IMapper mapper, IHostingEnvironment environment, ISitemapService sitemapService)
        {
            _postService = postService;
            _mapper = mapper;
            _environment = environment;
            _sitemapService = sitemapService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult GetAllPublishedPosts()
        {
            return Ok(_mapper.Map<IEnumerable<PostDto>>(_postService.GetAllPublishedPosts()));
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult GetAllPostsOnCategory(string id)
        {
            return Ok(_mapper.Map<IEnumerable<PostDto>>(_postService.GetAllPostsOnCategory(id)));
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult GetPostOnUrl(string id)
        {
            return Ok(_mapper.Map<PostDto>(_postService.GetPostOnUrl(id)));
        }

        [HttpGet]
        public IActionResult GetPost(int id)
        {
            return Ok(_mapper.Map<PostDto>(_postService.GetPost(id)));
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            return Ok(_mapper.Map<IEnumerable<PostDto>>(_postService.GetAllPosts().OrderByDescending(a => a.Created)));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadPostImage(IFormFile file)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "images/blogpost");

            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok($"/images/blogpost/{file.FileName}");
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