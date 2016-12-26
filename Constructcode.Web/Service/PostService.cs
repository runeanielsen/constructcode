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
        private readonly IHostingEnvironment _environment;
        private readonly IMemoryCache _memoryCache;

        private const string CachePostKey = "posts";

        public PostService(IUnitOfWork unitOfWork, IHostingEnvironment environment, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _memoryCache = memoryCache;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return Posts();
        }

        public IEnumerable<Post> GetAllPublishedPosts()
        {
            return Posts().Where(a => a.Published).OrderByDescending(a => a.Created).ToList();
        }

        public IEnumerable<Post> GetAllPostsOnCategory(string categoryUrl)
        {
            return Posts().Where(a => a.PostCategories.Any(b => b.Category.Url == categoryUrl) && a.Published);
        }

        public Post GetPost(int id)
        {
            return Posts().FirstOrDefault(a => a.Id == id);
        }

        public void CreatePost(Post post)
        {
            post.UpdateUrl();
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
            UpdateSiteMap();
            UpdateCachedPosts();
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
            UpdateSiteMap();
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

        public Validation ValidatePost(Post post)
        {
            if (post.Title == string.Empty)
                return new Validation(false, "Post title cannot be empty", HttpStatusCode.BadRequest);

            if (_unitOfWork.Posts.Find(a => string.Equals(a.Title, post.Title, StringComparison.CurrentCultureIgnoreCase) && a.Id != post.Id).Any())
                return new Validation(false, "Another post with that title already exist", HttpStatusCode.BadRequest);

            return new Validation(true);
        }

        private IEnumerable<Post> Posts()
        {
            IEnumerable<Post> posts;

            if (!_memoryCache.TryGetValue(CachePostKey, out posts))
            {
                posts = UpdateCachedPosts();
            }

            return posts;
        }
         
        
        private IEnumerable<Post> UpdateCachedPosts()
        {
            IEnumerable<Post> posts = _unitOfWork.Posts.GetAll().ToList();
            _memoryCache.Set(CachePostKey, posts, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(120)));

            return posts;
        }   

        private void UpdateSiteMap()
        {
            var logFile = File.Create(Path.Combine(_environment.WebRootPath, "sitemap.xml"));

            using (var stream = new StreamWriter(logFile))
            {
                var sitemap = new Sitemap(stream);
                sitemap.WriteStartDocument();

                sitemap.WriteItem("http://www.constructcode.com", DateTime.Now, "daily", "1");

                foreach (var post in GetAllPublishedPosts())
                {
                    sitemap.WriteItem("http://www.constructcode.com/post/" + post.Url, post.Created, "monthly", "0.9");
                }

                sitemap.WriteEndDocument();
                sitemap.Close();
            }
        }
    }
}