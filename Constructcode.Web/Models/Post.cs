namespace Constructcode.Web.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string[] Tags { get; set; }
        public Category Category { get; set; }
    }
}