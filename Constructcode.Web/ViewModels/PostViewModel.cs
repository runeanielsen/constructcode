using System;

namespace Constructcode.Web.ViewModels
{
    public class PostViewModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public DateTime Created { get; set; }
    }
}