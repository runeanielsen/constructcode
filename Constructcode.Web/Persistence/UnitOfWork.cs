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

        public UnitOfWork()
        {
            _context = new DatabaseContext();
            Posts = new PostRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
