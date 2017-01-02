using System.Collections.Generic;
using Constructcode.Web.Core.Domain;

namespace Constructcode.Web.Service
{
    public interface IPostService
    {
        void CreatePost(Post post);
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetAllPublishedPosts();
        Post GetPost(int id);
        void UpdatePost(Post post);
        void DeletePost(int id);
        Post GetPostOnUrl(string url);
        IEnumerable<Post> GetAllPostsOnCategory(string categoryUrl);
        IEnumerable<Post> GetPostsOnPageNumber(int pageNumber);
        int GetMaxPostCount();
        int GetMaxPageCount();
        Validation ValidatePost(Post post);
    }
}