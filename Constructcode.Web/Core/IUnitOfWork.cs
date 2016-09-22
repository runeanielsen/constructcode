using System;
using Constructcode.Web.Core.Repositories;

namespace Constructcode.Web.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        ICategoryRepository Categories { get; }

        int Complete();
    }
}
