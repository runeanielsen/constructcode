using System.Collections.Generic;

namespace Constructcode.Web.ApiControllers.DataTransferObjects
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
        public string Created { get; set; }
        public IEnumerable<PostCategoryDto> PostCategories { get; set; }
    }
}