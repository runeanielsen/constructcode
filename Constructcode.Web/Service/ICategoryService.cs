using System.Collections.Generic;
using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Service
{
    public interface ICategoryService
    {
        Category CreateCategory(Category category);
        IEnumerable<Category> GetAllCategories();
    }
}
