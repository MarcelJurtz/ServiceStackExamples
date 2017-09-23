using System;
using Funq;
using ServiceStack;
using ServiceStack.Caching;
using ServiceStack.Auth;

namespace RESTfulDemoServer
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var appHost = new HelloAppHost();
            appHost.Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
    public class HelloAppHost : AppHostBase
    {
        public HelloAppHost() : base("Hello Web Services", typeof(HelloService).Assembly) { }
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                DefaultContentType = MimeTypes.Json
            });
            // Authentication
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[] {
                new CustomAuthenticationProvider()
                }
            ));

            Plugins.Add(new RegistrationFeature());
            container.Register<ICacheClient>(new MemoryCacheClient());
            var userRep = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRep);
        }
    }
}