using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ViewModels;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.GetIntroduction()));

            CreateMap<PostViewModel, Post>();
        }
    }
}