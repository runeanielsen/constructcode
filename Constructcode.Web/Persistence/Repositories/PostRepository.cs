using Constructcode.Web.Core.Domain;
using Constructcode.Web.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Constructcode.Web.Persistence.Repositories
{
    public class PostRepository : Repository<Post>,  IPostRepository
    {
        public PostRepository(DbContext context) 
            : base(context)
        {
        }

        public DatabaseContext PlutoContext => Context as DatabaseContext;
    }
}