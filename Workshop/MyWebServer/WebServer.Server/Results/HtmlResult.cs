namespace WebServer.Server.Results
{
    using WebServer.Server.Http;

    public class HtmlResult : ContentResult
    {
        public HtmlResult(HttpResponse response, string html) : base(response, html, HttpContentType.Html)
        {
        }
    }
}
