using System.Collections.Generic;
using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Service
{
    public interface IPostService
    {
        void CreatePost(Post post);
        IEnumerable<Post> GetAllPosts();
        Post GetBlogPost(int id);
        void UpdatePost(Post post);
        void DeletePost(int id);
        Post GetPostOnUrl(string url);
    }
}