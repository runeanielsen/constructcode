using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ViewModels;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, LoginViewModel>();
            CreateMap<LoginViewModel, Account>();
        }
    }
}