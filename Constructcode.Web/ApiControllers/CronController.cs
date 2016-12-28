using Constructcode.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Constructcode.Web.ApiControllers
{
    public class CronController : Controller
    {
        private readonly ISitemapService _sitemapService;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public CronController(ISitemapService sitemapService, IPostService postService, ICategoryService categoryService)
        {
            _sitemapService = sitemapService;
            _postService = postService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GenerateSitemap()
        {
            _sitemapService.UpdateSitemap(_postService.GetAllPublishedPosts().ToList(), _categoryService.GetAllCategories().ToList());
            return Ok();
        }
    }
}
