using AutoMapper;
using Constructcode.Web.Core.Domain;
using Constructcode.Web.ApiControllers.DataTransferObjects;

namespace Constructcode.Web.Configurations.MappingConfigurations
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, LoginDto>();
            CreateMap<LoginDto, Account>();
        }
    }
}