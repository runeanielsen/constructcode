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
        IEnumerable<Post> GetPostsOnPageNumber(int pageNumber, string categoryUrl);
        int GetMaxPostCount();
        int GetMaxPostCount(string categoryUrl);
        int GetMaxPageCount();
        int GetMaxPageCount(string categoryUrl);
        Validation ValidatePost(Post post);
    }
}