using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Constructcode.Web.Configurations
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseStaticResources(this IApplicationBuilder app, IHostingEnvironment env)
        {
            ConfigureCacheControl(app);
            ConfigureAvailableDirectories(app, env);

            return app;
        }

        private static void ConfigureAvailableDirectories(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsProduction())
            {
                const string acmeChallengeDirectory = @".well-known/acme-challenge";
                var staticContentPath = Path.Combine(env.ContentRootPath, acmeChallengeDirectory);
                app.UseStaticFiles(new StaticFileOptions
                {
                    RequestPath = $"/{acmeChallengeDirectory}",
                    FileProvider = new PhysicalFileProvider(staticContentPath)
                });
            }
        }

        private static void ConfigureCacheControl(IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse =
                    r =>
                    {
                        var path = r.File.PhysicalPath;
                        if (path.EndsWith(".css")
                            || path.EndsWith(".js")
                            || path.EndsWith(".gif")
                            || path.EndsWith(".jpg")
                            || path.EndsWith(".png")
                            || path.EndsWith(".svg"))
                        {
                            var maxAge = new TimeSpan(10, 0, 0, 0);
                            r.Context.Response.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
                        }
                    }
            });
        }
    }
}
