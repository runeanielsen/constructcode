using System.Collections.Generic;

namespace Constructcode.Web.ApiControllers.DataTransferObjects
{
    public class EditPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
        public string Introduction { get; set; }
        public string Created { get; set; }
        public IEnumerable<PostCategoryDto> PostCategories { get; set; }
    }
}