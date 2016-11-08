using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ViewModels;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryViewModel, Category>();
            CreateMap<Category, CreateCategoryViewModel>();

            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
