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
        private const string DateTimeFormat = "dd MMMM yyyy";
        private const string Culture = "en-GB";

        public PostProfile()
        {
            #region Data Transfer Objects
            CreateMap<Post, PostDto>()
                 .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.Introduction))
                 .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created.ToString(DateTimeFormat, new CultureInfo(Culture))))
                 .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PostCategories.Select(a => a.Category)));
            CreateMap<PostDto, Post>();

            CreateMap<CreatePostDto, Post>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.ParseExact(src.Created, DateTimeFormat, new CultureInfo(Culture))));
            CreateMap<Post, CreatePostDto>();

            CreateMap<EditPostDto, Post>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.ParseExact(src.Created, DateTimeFormat, new CultureInfo(Culture))));
            CreateMap<Post, EditPostDto>();
            #endregion

            #region View Models
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.Introduction))
                .ForMember(dest => dest.PublishedTime, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created.ToString(DateTimeFormat, new CultureInfo(Culture))))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PostCategories.Select(a => a.Category)))
                .ForMember(dest => dest.SeoMetaDescription, opt => opt.MapFrom(src => src.GetSeoDescription()));
            CreateMap<PostViewModel, Post>();
            #endregion
        }
    }
}