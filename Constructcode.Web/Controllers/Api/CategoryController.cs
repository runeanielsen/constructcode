using System.Collections.Generic;
using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service;
using Constructcode.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Constructcode.Web.Controllers.Api
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCategoryViewModel vm)
        {
            var createdCategory = _categoryService.CreateCategory(_mapper.Map<Category>(vm));
            return Ok(_mapper.Map<CategoryViewModel>(createdCategory));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAllCategories()));
        }

        [HttpPost]
        public IActionResult Edit([FromBody]CategoryViewModel vm)
        {
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
