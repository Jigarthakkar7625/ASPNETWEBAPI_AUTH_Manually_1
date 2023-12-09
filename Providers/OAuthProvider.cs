using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace ASPNETWEBAPI_AUTH_Manually_1.Providers
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var db = new MVKINH_Auth_ManullayEntities())
            {
                if (db != null)
                {
                    //var empl = db.Employees.ToList(); // .ToList() >> LINQ
                    var user = db.Users.ToList();
                    if (user != null)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(user.Where(u => u.UserName == context.UserName && u.Password == context.Password).FirstOrDefault().UserName))
                            {
                                identity.AddClaim(new Claim("Age", "16"));
                                // Roles : Get data from Roles table

                                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                                context.Validated(identity);
                            }
                        }
                        catch (Exception)
                        {

                            context.SetError("invalid_grant", "Provided username and password is incorrect");
                            context.Rejected();
                            //throw;
                        }
                        //if (!string.IsNullOrEmpty(user.Where(u => u.UserName == context.UserName && u.Password == context.Password).FirstOrDefault().UserName))
                        //{
                        //    identity.AddClaim(new Claim("Age", "16"));
                        //    // Roles : Get data from Roles table

                        //    identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                        //    context.Validated(identity);
                        //}
                        //else
                        //{
                        //}
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    context.Rejected();
                }
                return;
            }

        }

    }
}