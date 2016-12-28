using Constructcode.Web.Core.Domain;
using System.Collections.Generic;

namespace Constructcode.Web.Service
{
    public interface ISitemapService
    {
        void UpdateSitemap(List<Post> posts, List<Category> categories);
    }
}
