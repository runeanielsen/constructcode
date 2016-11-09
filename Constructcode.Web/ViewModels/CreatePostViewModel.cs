using System.Collections.Generic;

namespace Constructcode.Web.ViewModels
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<PostCategoryViewModel> PostCategories { get; set; }
    }
}