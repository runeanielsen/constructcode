using Constructcode.Web.Core.Domain;
using Constructcode.Web.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public DatabaseContext DatabaseContext => Context as DatabaseContext;

        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}