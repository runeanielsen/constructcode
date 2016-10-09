using System;

namespace Constructcode.Web.ViewModels
{
    public class BlogPostViewModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public DateTime Created { get; set; }
    }
}