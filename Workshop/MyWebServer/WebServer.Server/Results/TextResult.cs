namespace WebServer.Server.Results
{
    using WebServer.Server.Http;

    public class TextResult : ContentResult
    {
        public TextResult(HttpResponse response, string text)
            : base(response, text, HttpContentType.PlainText)
        {
        }
    }
}
