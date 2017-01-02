using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Controllers.ViewModels;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class PostCategoryProfile : Profile
    {
        public PostCategoryProfile()
        {
            #region Data Transfer Objects
            CreateMap<PostCategory, PostCategoryDto>();
            CreateMap<PostCategoryDto, PostCategory>();
            #endregion

            #region View Models
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<PostCategoryViewModel, PostCategory>();
            #endregion
        }
    }
}
