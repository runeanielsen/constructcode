using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Constructcode.Web.Service
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;

        public FileService(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveBlogPostImage(IFormFile imageFile)
        {
            const string blogPostImageFolder = "images/blogpost";

            var destinationFolder = Path.Combine(_environment.WebRootPath, blogPostImageFolder);

            var generatedImageFileName = GenerateImageFileName();

            var filePath = Path.Combine(destinationFolder, generatedImageFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return blogPostImageFolder + generatedImageFileName;
        }

        private static string GenerateImageFileName()
        {
            return Guid.NewGuid() + ".png";
        }
    }
}
