using System.Collections.Generic;

namespace Constructcode.Web.Controllers.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Created { get; set; }
        public string Content { get; set; }
        public string SeoMetaDescription { get; set; }
        public bool Published { get; set; }
        public IEnumerable<PostCategoryViewModel> PostCategories { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
