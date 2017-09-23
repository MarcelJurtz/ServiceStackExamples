using System;
using ServiceStack;

namespace RESTfulDemoServer
{
    [Authenticate]
    [Route("/hello/{name*}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }
    public class HelloResponse
    {
        public string Result { get; set; }
    }
    public class HelloService : IService
    {
        public object Post(Hello request)
        {
            var name = String.IsNullOrEmpty(request.Name) ? "World" : request.Name;
            return new HelloResponse { Result = $"Hello, {name}!" };
        }
    }
}