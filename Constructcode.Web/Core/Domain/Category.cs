using System.Collections.Generic;

namespace Constructcode.Web.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}