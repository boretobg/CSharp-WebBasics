namespace WebServer.Server.Controllers
{
    using WebServer.Server.Http;

    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute() : base(HttpMethod.Post)
        {

        }
    }
}
