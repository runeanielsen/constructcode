using System.Collections.Generic;
using Constructcode.Web.Core;
using Constructcode.Web.Core.Domain;
using System.Linq;

namespace Constructcode.Web.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePost(Post post)
        {
            post.SetCreatedTime();
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _unitOfWork.Posts.GetAll();
        }

        public Post GetBlogPost(int id)
        {
            return _unitOfWork.Posts.Get(id);
        }

        public void UpdatePost(Post post)
        {
            var postCategories = _unitOfWork.PostCategories.Find(pc => pc.PostId == post.Id).ToList();
            _unitOfWork.PostCategories.RemoveRange(postCategories);
            _unitOfWork.Complete();

            _unitOfWork.PostCategories.AddRange(post.PostCategories);
            _unitOfWork.Posts.Update(post);      
            _unitOfWork.Complete();
        }

        public void DeletePost(int id)
        {
            _unitOfWork.Posts.Remove(_unitOfWork.Posts.SingleOrDefault(a => a.Id == id));
            _unitOfWork.Complete();
        }
    }
}