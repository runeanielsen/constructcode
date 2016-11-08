using System.Collections.Generic;

namespace Constructcode.Web.ViewModels
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}