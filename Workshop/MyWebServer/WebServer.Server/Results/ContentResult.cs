namespace WebServer.Server.Results
{
    using WebServer.Server.Http;

    public class ContentResult : ActionResult
    {
        public ContentResult(
        HttpResponse response,
            string content,
            string contentType)
            : base(response)
            => this.SetContent(content, contentType);
    }
}
