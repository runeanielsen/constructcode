﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Constructcode.Web.Core;
using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Category CreateCategory(Category category)
        {
            category.UpdateUrl();
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Complete();

            return category;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public void EditCategory(Category category)
        {
            var categoryAlreadyExist = _unitOfWork.Categories
                    .Find(a => string.Equals(a.Title, category.Title, StringComparison.CurrentCultureIgnoreCase))
                    .Any();

            if (!categoryAlreadyExist)
                return;

            category.UpdateUrl();
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Complete();
        }

        public void DeleteCategory(int categoryId)
        {
            _unitOfWork.Categories.Remove(_unitOfWork.Categories.SingleOrDefault(a => a.Id == categoryId));
            _unitOfWork.Complete();
        }

        public Validation ValidateCategory(Category category)
        {
            if (category.Title == string.Empty)
                return new Validation(false, "Category name cannot be empty", HttpStatusCode.BadRequest);

            if (_unitOfWork.Categories.Find(a => string.Equals(a.Title, category.Title, StringComparison.CurrentCultureIgnoreCase) && a.Id != category.Id).Any())
                return new Validation(false, "A category with that name already exists", HttpStatusCode.BadRequest);

            return new Validation(true);
        }

        public Category GetCategoryOnUrl(string url)
        {
            return _unitOfWork.Categories.SingleOrDefault(a => a.Url == url);
        }
    }
}
