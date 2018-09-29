using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Constructcode.Web.Configurations
{
    public static class AuthenticationMiddlewareConfig
    {
        public static void SetupAuthenticationMiddlewareConfig(this IServiceCollection service)
        {
            service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = new PathString("/Account/UnAuthorized/");
                    o.AccessDeniedPath = new PathString("/Account/Forbidden/");
                    o.SlidingExpiration = true;
                });
        }
    }
}
