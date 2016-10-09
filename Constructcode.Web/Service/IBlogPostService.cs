using System.Collections.Generic;
using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Service
{
    public interface IBlogPostService
    {
        void Save(Post post);
        IEnumerable<Post> GetAllBlogPosts();
    }
}