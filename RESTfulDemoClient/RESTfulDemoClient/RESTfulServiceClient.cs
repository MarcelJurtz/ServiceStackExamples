using System;
using ServiceStack;

namespace RESTfulDemoClient
{
    class RESTfulServiceClient : IDisposable
    {
        private const String url = "http://localhost:64424";
        private JsonServiceClient serviceclient;

        private JsonServiceClient getServiceClient(String usern, String passw)
        {
            if(serviceclient == null)
            {
                serviceclient = new JsonServiceClient(url);

                var authResponse = serviceclient.Post(new Authenticate
                {
                    provider = CustomAuthenticationProvider.Name, //= credentials
                    UserName = usern,
                    Password = passw,
                    RememberMe = true,
                });

                serviceclient.AlwaysSendBasicAuthHeader = true;
            }
            return serviceclient;
        }

        public HelloResponse GetHelloResponse(Hello request, String username, String password)
        {
            var client = this.getServiceClient(username, password);
            var response = client.Post(request);
            return response;
        }

        public void Dispose()
        {
            serviceclient = null;
        }
    }
}
