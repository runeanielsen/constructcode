using Constructcode.Web.Core.Domain;
using Constructcode.Web.Service.Helpers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Constructcode.Web.Service
{
    public class SitemapService : ISitemapService
    {
        private readonly IHostingEnvironment _environment;
        private const string websiteDomainName = "http://www.constructcode.com";

        public SitemapService(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void UpdatePosts(IEnumerable<Post> posts)
        {
            var logFile = File.Create(Path.Combine(_environment.WebRootPath, "sitemap-posts.xml"));

            using (var stream = new StreamWriter(logFile))
            {
                var sitemap = new Sitemap(stream);
                sitemap.WriteStartDocument();

                sitemap.WriteItem(websiteDomainName, DateTime.Now, "daily", "1");

                foreach (var post in posts)
                {
                    sitemap.WriteItem($"{websiteDomainName}/post/{post.Url}", post.Created, "weekly", "0.8");
                }

                sitemap.WriteEndDocument();
                sitemap.Close();

                UpdateAllSitemaps();
            }
        }

        private void UpdateAllSitemaps()
        {
            UpdatePages();
            UpdateIndexSitemap();
        }

        private void UpdatePages()
        {
            var logFile = File.Create(Path.Combine(_environment.WebRootPath, "sitemap-pages.xml"));

            using (var stream = new StreamWriter(logFile))
            {
                var sitemap = new Sitemap(stream);
                sitemap.WriteStartDocument();

                sitemap.WriteItem(websiteDomainName, DateTime.Now, "daily", "1");

                sitemap.WriteEndDocument();
                sitemap.Close();
            }
        }

        private void UpdateIndexSitemap()
        {
            var logFile = File.Create(Path.Combine(_environment.WebRootPath, "sitemap.xml"));

            using (var stream = new StreamWriter(logFile))
            {
                var sitemap = new SitemapIndex(stream);
                sitemap.WriteStartDocument();

                sitemap.WriteItem($"{websiteDomainName}/sitemap-pages.xml", DateTime.Now);
                sitemap.WriteItem($"{websiteDomainName}/sitemap-posts.xml", DateTime.Now);

                sitemap.WriteEndDocument();
                sitemap.Close();
            }
        }
    }
}