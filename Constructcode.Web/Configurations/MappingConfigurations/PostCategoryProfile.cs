using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ViewModels;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class PostCategoryProfile : Profile
    {
        public PostCategoryProfile()
        {
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<PostCategoryViewModel, PostCategory>();
        }
    }
}
