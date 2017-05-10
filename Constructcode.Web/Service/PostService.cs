using System;
using System.Collections.Generic;
using Constructcode.Web.Core;
using Constructcode.Web.Core.Domain;
using System.Linq;
using System.Net;
using Constructcode.Web.Service.Helpers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;

namespace Constructcode.Web.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        private const string CachePostKey = "posts";
        private const int PostPerPage = 5;

        public PostService(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return Posts();
        }

        public IEnumerable<Post> GetAllPublishedPosts()
        {
            return Posts()
                    .Where(a => a.Published && a.Created <= DateTime.Today)
                    .OrderByDescending(a => a.Created).ToList();
        }

        public IEnumerable<Post> GetAllPostsOnCategory(string categoryUrl)
        {
            return GetAllPublishedPosts()
                    .Where(a => a.PostCategories
                    .Any(b => b.Category.Url == categoryUrl));
        }

        public Post GetPost(int id)
        {
            return Posts().FirstOrDefault(a => a.Id == id);
        }

        public void CreatePost(Post post)
        {
            post.ManageUpdate();
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
            UpdateCachedPosts();
        }

        public void UpdatePost(Post post)
        {
            var postCategories = _unitOfWork.PostCategories.Find(pc => pc.PostId == post.Id).ToList();
            _unitOfWork.PostCategories.RemoveRange(postCategories);
            _unitOfWork.Complete();

            post.ManageUpdate();
            _unitOfWork.PostCategories.AddRange(post.PostCategories);
            _unitOfWork.Posts.Update(post);
            _unitOfWork.Complete();
            UpdateCachedPosts();
        }

        public void DeletePost(int id)
        {
            _unitOfWork.Posts.Remove(_unitOfWork.Posts.SingleOrDefault(a => a.Id == id));
            _unitOfWork.Complete();
            UpdateCachedPosts();
        }

        public Post GetPostOnUrl(string url)
        {
            return Posts().SingleOrDefault(a => a.Url == url);
        }

        public IEnumerable<Post> GetPostsOnPageNumber(int pageNumber)
        {
            return GetAllPublishedPosts()
                    .Skip(PostPerPage * (pageNumber - 1))
                    .Take(PostPerPage);
        }

        public IEnumerable<Post> GetPostsOnPageNumber(int pageNumber, string categoryUrl)
        {
            return GetAllPostsOnCategory(categoryUrl)
                    .Skip(PostPerPage * (pageNumber - 1))
                    .Take(PostPerPage).OrderByDescending(a => a.Created);
        }

        public Validation ValidatePost(Post post)
        {
            if (post.Title == string.Empty)
                return new Validation(false, "Post title cannot be empty", HttpStatusCode.BadRequest);

            if (_unitOfWork.Posts.Find(a => string.Equals(a.Title, post.Title, StringComparison.CurrentCultureIgnoreCase) && a.Id != post.Id).Any())
                return new Validation(false, "Another post with that title already exist", HttpStatusCode.BadRequest);

            return new Validation(true);
        }

        public int GetMaxPostCount()
        {
            return GetAllPublishedPosts().Count();
        }

        public int GetMaxPostCount(string categoryUrl)
        {
            return GetAllPostsOnCategory(categoryUrl).Count();
        }

        public int GetMaxPageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(GetMaxPostCount()) / PostPerPage));
        }

        public int GetMaxPageCount(string categoryUrl)
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(GetMaxPostCount(categoryUrl)) / PostPerPage));
        }

        private IEnumerable<Post> Posts()
        {
            if (!_memoryCache.TryGetValue(CachePostKey, out IEnumerable<Post> posts))
            {
                posts = UpdateCachedPosts();
            }

            return posts;
        }

        private IEnumerable<Post> UpdateCachedPosts()
        {
            IEnumerable<Post> posts = _unitOfWork.Posts.GetAll().ToList();
            _memoryCache.Set(CachePostKey, posts);

            return posts;
        }
    }
}