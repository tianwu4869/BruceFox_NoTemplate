using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System.IdentityModel.Tokens.Jwt;
using Owin;
using BF.Entity;


[assembly: OwinStartup(typeof(BF.Infrastructure.Startup))]

namespace BF.Infrastructure
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            OAuthAuthorizationServerOptions OAuthOptions = new OAuthAuthorizationServerOptions {
                TokenEndpointPath = new PathString("/token"),
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                Provider = new MyAuthorizationServerProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://scarletglove.gov")
            };

            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
