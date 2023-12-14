using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPNETWEBAPI_AUTH_Manually_1.Providers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(ASPNETWEBAPI_AUTH_Manually_1.Startup))]

namespace ASPNETWEBAPI_AUTH_Manually_1
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
             new JwtBearerAuthenticationOptions
             {
                 AuthenticationMode = AuthenticationMode.Active,
                 TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "https://localhost:44393/", //some string, normally web url,  
                     ValidAudience = "https://localhost:44393/",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("E9DB7E89123F52A9F2DB04EF04C7FE88"))
                 }
             }
             );


            //PublicClientId = "self";
            //OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/Token"),
            //    Provider = new OAuthProvider(),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            //    AllowInsecureHttp = true,
            //};

            //app.UseOAuthBearerTokens(OAuthOptions);
            //app.UseOAuthAuthorizationServer(OAuthOptions);
            // ConfigureAuth(app);
        }
    }
}
