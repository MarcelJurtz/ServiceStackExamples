using System.Collections.Generic;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;

namespace RESTfulDemoServer
{
    public class CustomAuthenticationProvider : CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService,
        string userName, string password)
        {
            // Only checks if username equals password
            // implement custom logic here
            return userName.Equals(password);
        }
        public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            //session.customElement = "Hello World";
            return base.OnAuthenticated(authService, session, tokens, authInfo);
        }
    }
}