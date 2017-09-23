using ServiceStack;

namespace RESTfulDemoClient
{
    [Route("/hello/{name*}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }
    public class HelloResponse
    {
        public string Result { get; set; }
    }
}
