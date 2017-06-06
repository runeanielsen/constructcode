using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Constructcode.Web.Configurations
{
    public static class AuthenticationMiddlewareConfig
    {
        public const string AuthenticationCookieName = "Authentication";

        public static void SetupAuthenticationMiddlewareConfig(this IApplicationBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = AuthenticationCookieName,
                LoginPath = new PathString("/Account/UnAuthorized/"),
                AccessDeniedPath = new PathString("/Account/Forbidden/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                SlidingExpiration = true
            });
        }
    }
}
