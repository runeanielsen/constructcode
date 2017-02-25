using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Constructcode.Web.Service
{
    public interface IFileService
    {
        Task<string> SaveBlogPostImage(IFormFile imageFile);
    }
}
