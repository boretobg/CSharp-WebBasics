namespace WebServer.Server.Results
{
    using WebServer.Server.Http;

    public class RedirectResult : ActionResult
    {
        public RedirectResult(HttpResponse response, string location)
            : base(response)
        {
            this.StatusCode = HttpStatusCode.Found;

            this.AddHeader(HttpHeader.Location, location);
        }
    }
}
