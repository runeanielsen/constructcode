using System;
using Constructcode.Web.Core.Repositories;

namespace Constructcode.Web.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        ICategoryRepository Categories { get; }
        IAccountRepository Accounts { get; }
        IPostCategoryRepository PostCategories { get; }

        void Complete();
    }
}
