using Constructcode.Web.Core.Domain;
using Constructcode.Web.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.Repositories
{
    public class PostCategoryRepository : Repository<PostCategory>, IPostCategoryRepository
    {
        private DatabaseContext DatabaseContext => Context as DatabaseContext;

        public PostCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}