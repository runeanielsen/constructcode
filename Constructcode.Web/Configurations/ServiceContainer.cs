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

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IBlogPostService, BlogPostService>();
        }
    }
}
