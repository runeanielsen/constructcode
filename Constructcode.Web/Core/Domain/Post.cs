using System;
using System.Collections.Generic;

namespace Constructcode.Web.Core.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }

        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<PostCategory> PostCategories { get; set; }

        public Post()
        {
            Created = DateTime.Now;
        }

        public string GetIntroduction()
        {
            return Content.Substring(0, Content.Length > 255 ? 255 : Content.Length);
        }
    }
}