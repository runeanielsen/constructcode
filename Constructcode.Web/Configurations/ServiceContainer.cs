using AutoMapper;
using Constructcode.Web.Configurations.MappingConfigurations;
using Constructcode.Web.Core;
using Constructcode.Web.Persistence;
using Constructcode.Web.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Constructcode.Web.Configurations
{
    public class ServiceContainer
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<DatabaseContext>();
            services.AddEntityFrameworkSqlServer();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PostProfile>();
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<CategoryProfile>();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}