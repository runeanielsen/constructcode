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

        public void CreateCategory(Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Complete();
        }
    }
}
