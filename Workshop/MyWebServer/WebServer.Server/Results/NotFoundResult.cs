namespace WebServer.Server.Results
{
    using WebServer.Server.Http;

    public class NotFoundResult : ActionResult
    {
        public NotFoundResult(HttpResponse response)
            : base(response)
            => this.StatusCode = HttpStatusCode.NotFound;
    }
}
