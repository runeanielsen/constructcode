using System;
using System.Collections.Generic;
using Constructcode.Web.Core;
using Constructcode.Web.Core.Domain;
using System.Linq;
using System.Net;

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
            post.UpdateUrl();
            post.SetCreatedTime();
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _unitOfWork.Posts.GetAll();
        }

        public IEnumerable<Post> GetAllPostsOnCategory(string categoryUrl)
        {
            return _unitOfWork.Posts.GetAll().Where(a => a.PostCategories.Any(b => b.Category.Url == categoryUrl));
        }

        public Post GetPost(int id)
        {
            return _unitOfWork.Posts.Get(id);
        }

        public void UpdatePost(Post post)
        {
            var postCategories = _unitOfWork.PostCategories.Find(pc => pc.PostId == post.Id).ToList();
            _unitOfWork.PostCategories.RemoveRange(postCategories);
            _unitOfWork.Complete();

            post.UpdateUrl();
            _unitOfWork.PostCategories.AddRange(post.PostCategories);
            _unitOfWork.Posts.Update(post);
            _unitOfWork.Complete();
        }

        public void DeletePost(int id)
        {
            _unitOfWork.Posts.Remove(_unitOfWork.Posts.SingleOrDefault(a => a.Id == id));
            _unitOfWork.Complete();
        }

        public Post GetPostOnUrl(string url)
        {
            return _unitOfWork.Posts.SingleOrDefault(a => a.Url == url);
        }

        public Validation ValidatePost(Post post)
        {
            if (post.Title == string.Empty)
                return new Validation(false, "Post title cannot be empty", HttpStatusCode.BadRequest);

            if (_unitOfWork.Posts.Find(a => string.Equals(a.Title, post.Title, StringComparison.CurrentCultureIgnoreCase) && a.Id != post.Id).Any())
                return new Validation(false, "Another post with that title already exist", HttpStatusCode.BadRequest);

            return new Validation(true);
        }
    }
}