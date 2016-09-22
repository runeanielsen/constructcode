using Constructcode.Web.Core.Domain;
using Constructcode.Web.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) 
            : base(context)
        {
        }

        public DatabaseContext PlutoContext => Context as DatabaseContext;
    }
}