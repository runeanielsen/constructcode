using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service.Helpers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Constructcode.Web.Service
{
    public class SitemapService : ISitemapService
    {
        private readonly IHostingEnvironment _environment;
        private readonly string _websiteDomainName;

        public SitemapService(IHostingEnvironment environment, IConfigurationRoot configuration)
        {
            _environment = environment;
            _websiteDomainName = configuration["Domain:Url"];
        }

        public void UpdateSitemap(List<Post> posts, List<Category> categories)
        {
            var mostRecentlyModifiedPost = posts.OrderByDescending(a => a.LastModified).First().LastModified;

            UpdatePosts(posts);
            UpdateCategories(categories, posts);
            UpdatePages(mostRecentlyModifiedPost);
            UpdateIndexSitemap(mostRecentlyModifiedPost);
        }

        private void UpdatePosts(IEnumerable<Post> posts)
        {
            var logFile = File.Create(Path.Combine(_environment.WebRootPath, "sitemap-posts.xml"));

            using (var stream = new StreamWriter(logFile))
            {
                var sitemap = new Sitemap(stream);
                sitemap.WriteStartDocument();

                foreach (var post in posts)
                {
                    sitemap.WriteItem($"{_websiteDomainName}/post/{post.Url}", post.LastModified, "weekly", "0.8");
                }

                sitemap.WriteEndDocument();
                sitemap.Close();
            }
        }

        private void UpdateCategories(IEnumerable<Category> categories, IEnumerable<Post> posts)
        {
            var logFile = File.Create(Path.Combine(_environment.WebRootPath, "sitemap-categories.xml"));

            using (var stream = new StreamWriter(logFile))
            {
                var sitemap = new Sitemap(stream);
                sitemap.WriteStartDocument();

                foreach (var category in categories)
                {
                    var lastModifiedPostOnCategory = posts.FirstOrDefault(a => a.PostCategories.Any(b => b.CategoryId == category.Id));

                    if (lastModifiedPostOnCategory != null)
                    {
                        sitemap.WriteItem($"{_websiteDomainName}/post/category/{category.Url}",
                            lastModifiedPostOnCategory.LastModified, "weekly", "0.8");
                    }
                }

                sitemap.WriteEndDocument();
                sitemap.Close();
            }
        }

        private void UpdatePages(DateTime lastModified)
        {
            var logFile = File.Create(Path.Combine(_environment.WebRootPath, "sitemap-pages.xml"));

            using (var stream = new StreamWriter(logFile))
            {
                var sitemap = new Sitemap(stream);
                sitemap.WriteStartDocument();

                sitemap.WriteItem(_websiteDomainName, lastModified, "daily", "1");

                sitemap.WriteEndDocument();
                sitemap.Close();
            }
        }

        private void UpdateIndexSitemap(DateTime lastModified)
        {
            var logFile = File.Create(Path.Combine(_environment.WebRootPath, "sitemap.xml"));

            using (var stream = new StreamWriter(logFile))
            {
                var sitemap = new SitemapIndex(stream);
                sitemap.WriteStartDocument();

                sitemap.WriteItem($"{_websiteDomainName}/sitemap-pages.xml", lastModified);
                sitemap.WriteItem($"{_websiteDomainName}/sitemap-posts.xml", lastModified);
                sitemap.WriteItem($"{_websiteDomainName}/sitemap-categories.xml", lastModified);

                sitemap.WriteEndDocument();
                sitemap.Close();
            }
        }
    }
}