using System.Collections.Generic;

namespace Constructcode.Web.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public List<PostCategory> PostCategories { get; set; }

        public void UpdateUrl()
        {
            Url = Title.ToLower().Replace(" ", "-");
            Url = Url.Replace(".", "-");
            Url = Url.Replace("#", "-sharp");
        }
    }
}