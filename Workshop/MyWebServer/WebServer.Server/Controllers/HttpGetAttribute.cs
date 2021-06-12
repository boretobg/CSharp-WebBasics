namespace WebServer.Server.Controllers
{
    using WebServer.Server.Http;
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute() : base(HttpMethod.Get)
        {
        }
    }
}
