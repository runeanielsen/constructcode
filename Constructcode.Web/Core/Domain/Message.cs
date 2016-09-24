namespace Constructcode.Web.Core.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}