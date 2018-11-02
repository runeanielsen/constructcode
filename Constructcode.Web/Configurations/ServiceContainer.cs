using AutoMapper;
using Constructcode.Web.Configurations.MappingConfigurations;
using Constructcode.Web.Core;
using Constructcode.Web.Persistence;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Constructcode.Web.Configurations
{
    public static class ServiceContainer
    {
        public static void Setup(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkSqlServer();
            services.AddMemoryCache();

            ConfigureGzipComperession(services);
            ConfigureAutoMapper(services);
            ConfigureApplication(services);
            ConfigureHttps(services);
        }

        private static void ConfigureHttps(IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }

        private static void ConfigureGzipComperession(IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options
                => options.Level = System.IO.Compression.CompressionLevel.Optimal);
        }

        private static void ConfigureApplication(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISitemapService, SitemapService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IDesignTimeDbContextFactory<DatabaseContext>, DatabaseContextFactory>();
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PostProfile>();
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<PostCategoryProfile>();
            });
        }
    }
}