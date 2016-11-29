using System.Collections.Generic;
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
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Complete();
        }

        public void DeleteCategory(int categoryId)
        {
            _unitOfWork.Categories.Remove(_unitOfWork.Categories.SingleOrDefault(a => a.Id == categoryId));
            _unitOfWork.Complete();
        }
    }
}
