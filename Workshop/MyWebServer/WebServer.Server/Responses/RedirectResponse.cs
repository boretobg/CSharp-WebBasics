namespace WebServer.Server.Responses
{
    using WebServer.Server.Http;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location)
            : base(HttpStatusCode.Found)
            => this.Headers.Add(HttpHeader.Location, new HttpHeader(HttpHeader.Location, location));
    }
}
