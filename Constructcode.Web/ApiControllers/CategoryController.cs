using System.Collections.Generic;
using AutoMapper;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.ApiControllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService, ISitemapService sitemapService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCategoryDto vm)
        {
            var mappedCategory = _mapper.Map<Category>(vm);

            var validation = _categoryService.ValidateCategory(mappedCategory);

            if (!validation.IsValid)
                return StatusCode(validation.StatusCodeAsIntegar, validation.Message);

            _categoryService.CreateCategory(mappedCategory);
            return Ok(_mapper.Map<CategoryDto>(mappedCategory));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(_categoryService.GetAllCategories()));
        }

        [HttpPost]
        public IActionResult Edit([FromBody]CategoryDto vm)
        {
            var mappedCategory = _mapper.Map<Category>(vm);

            var validation = _categoryService.ValidateCategory(mappedCategory);
            if (!validation.IsValid)
                return StatusCode(validation.StatusCodeAsIntegar, validation.Message);

            _categoryService.EditCategory(_mapper.Map<Category>(vm));

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
