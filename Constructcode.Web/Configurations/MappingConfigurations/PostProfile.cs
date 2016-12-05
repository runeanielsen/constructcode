using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ViewModels;
using System.Linq;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.GetIntroduction()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created.ToString("dd MMMM yyyy")))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PostCategories.Select(a => a.Category)));
            CreateMap<PostViewModel, Post>();

            CreateMap<CreatePostViewModel, Post>();
            CreateMap<Post, CreatePostViewModel>();

            CreateMap<EditPostViewModel, Post>();
            CreateMap<Post, EditPostViewModel>();
        }
    }
}