﻿using System.Collections.Generic;

namespace Constructcode.Web.ApiControllers.DataTransferObjects
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Created { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
        public IEnumerable<PostCategoryDto> PostCategories { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}