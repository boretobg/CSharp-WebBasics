namespace WebServer.Server.Responses
{
    using WebServer.Server.Http;

    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}
