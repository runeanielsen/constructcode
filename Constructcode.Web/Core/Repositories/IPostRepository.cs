using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Post Get(int id);
    }
}