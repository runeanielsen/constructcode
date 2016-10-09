using Constructcode.Web.Core;
using Constructcode.Web.Core.Domain;
using System.Linq;

namespace Constructcode.Web.Service
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogPostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Save(Post post)
        {
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
        }

        public void GetAllBlogPosts()
        {
            //_unitOfWork.Posts.GetAll().OrderBy(a => a.)
        }
    }
}
