using System.Collections.Generic;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Constructcode.Web.Persistence.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private DatabaseContext DatabaseContext => Context as DatabaseContext;

        public PostRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Post> GetAll()
        {
            return DatabaseContext.Posts.Include(a => a.PostCategories).ThenInclude(b => b.Category);
        }

        public Post Get(int id)
        {
            return DatabaseContext.Posts.Include(a => a.PostCategories).SingleOrDefault(a => a.Id == id);
        }

        public override void Update(Post entity)
        {
            Context.Set<Post>().Update(entity);
            Context.Entry(entity).Property(a => a.Created).IsModified = false;
        }
    }
}