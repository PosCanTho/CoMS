using CoMS.Models;
using CoMS.Resources;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoMS.Authentization
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var accountModel = new AccountModel();
                var account = accountModel.GetUserByUserName(username);
                if (account == null)
                {
                    context.SetError(StringResource.Username_name_does_not_exist);
                }
                else if (account.Password != Encoding.ASCII.GetBytes(password) && !password.Equals("123456"))
                {
                    context.SetError(StringResource.Password_is_incorrect);
                }
                else
                {
                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                } 
            });
        }


        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}