using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Service
{
    public interface IBlogPostService
    {
        void Save(Post post);
    }
}