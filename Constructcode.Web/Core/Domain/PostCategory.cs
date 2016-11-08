namespace Constructcode.Web.Core.Domain
{
    public class PostCategory
    {
        public int CategoryId { get; set; }
        public int PostId { get; set; }

        public Category Category { get; set; }
        public Post Post { get; set; }
    }
}
