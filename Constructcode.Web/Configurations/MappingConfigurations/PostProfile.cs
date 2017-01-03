using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using System.Linq;
using System;
using System.Globalization;
using Constructcode.Web.Controllers.ViewModels;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            #region Data Transfer Objects
            CreateMap<Post, PostDto>()
                 .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.GetIntroduction()))
                 .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created.ToString("dd MMMM yyyy", new CultureInfo("en-GB"))))
                 .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PostCategories.Select(a => a.Category)));
            CreateMap<PostDto, Post>();

            CreateMap<CreatePostDto, Post>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.ParseExact(src.Created, "dd MMMM yyyy", new CultureInfo("en-GB"))));
            CreateMap<Post, CreatePostDto>();

            CreateMap<EditPostDto, Post>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.ParseExact(src.Created, "dd MMMM yyyy", new CultureInfo("en-GB"))));
            CreateMap<Post, EditPostDto>();
            #endregion

            #region View Models
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.GetIntroduction()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created.ToString("dd MMMM yyyy", new CultureInfo("en-GB"))))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PostCategories.Select(a => a.Category)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.GetDescription()));
            CreateMap<PostViewModel, Post>();
            #endregion
        }
    }
}