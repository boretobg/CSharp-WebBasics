namespace WebServer.Server.Results
{
    using WebServer.Server.Http;

    public class BadRequestResult : HttpResponse
    {
        public BadRequestResult() : base(HttpStatusCode.BadRequest)
        {
        }
    }
}
