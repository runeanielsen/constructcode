using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.ApiControllers
{
    [Authorize]
    public class PostController : Controller
    {
        private const int ApiResponseCacheDuration = 120;

        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public PostController(IPostService postService, IMapper mapper, IFileService fileService)
        {
            _postService = postService;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet]
        [ResponseCache(Duration = ApiResponseCacheDuration)]
        public IActionResult GetAllPublishedPosts()
        {
            return Ok(_mapper.Map<IEnumerable<PostDto>>(_postService.GetAllPublishedPosts()));
        }

        [HttpGet]
        [ResponseCache(Duration = ApiResponseCacheDuration)]
        public IActionResult GetAllPostsOnCategory(string id)
        {
            return Ok(_mapper.Map<IEnumerable<PostDto>>(_postService.GetAllPostsOnCategory(id)));
        }

        [HttpGet]
        [ResponseCache(Duration = ApiResponseCacheDuration)]
        public IActionResult GetPostOnUrl(string id)
        {
            return Ok(_mapper.Map<PostDto>(_postService.GetPostOnUrl(id)));
        }

        [HttpGet]
        public IActionResult GetPost(int id)
        {
            return Ok(_mapper.Map<PostDto>(_postService.GetPost(id)));
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            return Ok(_mapper.Map<IEnumerable<PostDto>>(_postService.GetAllPosts().OrderByDescending(a => a.Created)));
        }

        [HttpPost]
        public async Task<IActionResult> UploadPostImage(IFormFile file)
        {
            var savedFileName = await _fileService.SaveBlogPostImage(file);

            return Ok(savedFileName);
        }

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

        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            _postService.DeletePost(id);

            return Ok();
        }
    }
}