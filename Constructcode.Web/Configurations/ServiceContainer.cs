using AutoMapper;
using Constructcode.Web.Configurations.MappingConfigurations;
using Constructcode.Web.Core;
using Constructcode.Web.Persistence;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
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

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Fastest);
            services.AddResponseCompression();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PostProfile>();
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<PostCategoryProfile>();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}