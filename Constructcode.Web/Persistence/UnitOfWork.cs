using Constructcode.Web.Core;
using Constructcode.Web.Core.Repositories;
using Constructcode.Web.Persistence.Repositories;

namespace Constructcode.Web.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public ICategoryRepository Categories { get; private set; }
        public IPostRepository Posts { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            Posts = new PostRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            throw new System.NotImplementedException();
        }
    }
}
