using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ViewModels;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
