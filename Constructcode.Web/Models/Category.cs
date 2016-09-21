using System.Collections.Generic;

namespace Constructcode.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}