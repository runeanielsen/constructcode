using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using System.Linq;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.GetIntroduction()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created.ToString("dd MMMM yyyy")))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PostCategories.Select(a => a.Category)));
            CreateMap<PostDto, Post>();

            CreateMap<CreatePostDto, Post>();
            CreateMap<Post, CreatePostDto>();

            CreateMap<EditPostDto, Post>();
            CreateMap<Post, EditPostDto>();
        }
    }
}