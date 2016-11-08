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

        public List<Message> Messages { get; set; }
        public List<PostCategory> PostCategories { get; set; }

        public Post()
        {
            Created = DateTime.Now;
        }

        public string GetIntroduction()
        {
            const int introductionTextLength = 700;

            return Content.Substring(0, Content.Length > introductionTextLength ? introductionTextLength : Content.Length);
        }
    }
}