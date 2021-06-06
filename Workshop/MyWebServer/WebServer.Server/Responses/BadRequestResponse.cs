
namespace WebServer.Server.Responses
{
    using WebServer.Server.Http;

    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse() : base(HttpStatusCode.BadRequest)
        {
        }
    }
}
