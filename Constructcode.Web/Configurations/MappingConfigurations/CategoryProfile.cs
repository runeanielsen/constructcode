using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Controllers.ViewModels;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            #region Data Transfers Objects
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            #endregion

            #region View Models
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();
            #endregion
        }
    }
}
