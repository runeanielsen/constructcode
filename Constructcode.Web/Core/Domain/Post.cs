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
        public DateTime LastModified { get; set; }
        public bool Published { get; set; }
        public string Introduction { get; set; }

        public List<Message> Messages { get; set; }
        public List<PostCategory> PostCategories { get; set; }


        public void ManageUpdate()
        {
            UpdateUrl();
            LastModified = DateTime.Now;
        }

        private void UpdateUrl()
        {
            Url = Title.ToLower().Replace(" ", "-");
            Url = Url.ToLower().Replace(".", "-");
        }
    }
}