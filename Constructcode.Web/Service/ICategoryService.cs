using System.Collections.Generic;
using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Service
{
    public interface ICategoryService
    {
        void CreateCategory(Category category);
        IEnumerable<Category> GetAllCategories();
    }
}
