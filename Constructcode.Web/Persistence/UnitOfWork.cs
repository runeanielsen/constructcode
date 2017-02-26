using Constructcode.Web.Core;
using Constructcode.Web.Core.Repositories;
using Constructcode.Web.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Constructcode.Web.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public ICategoryRepository Categories { get; }
        public IAccountRepository Accounts { get; }
        public IPostRepository Posts { get; }
        public IPostCategoryRepository PostCategories { get; set; }

        public UnitOfWork(IHostingEnvironment env, IConfigurationRoot configuration)
        {
            _context = new DatabaseContext(env, configuration);
            Posts = new PostRepository(_context);
            Categories = new CategoryRepository(_context);
            Accounts = new AccountRepository(_context);
            PostCategories = new PostCategoryRepository(_context);
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