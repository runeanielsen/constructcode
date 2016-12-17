using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ApiControllers.DataTransferObjects;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class PostCategoryProfile : Profile
    {
        public PostCategoryProfile()
        {
            CreateMap<PostCategory, PostCategoryDto>();
            CreateMap<PostCategoryDto, PostCategory>();
        }
    }
}
