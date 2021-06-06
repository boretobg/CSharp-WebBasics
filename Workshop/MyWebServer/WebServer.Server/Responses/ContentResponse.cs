namespace WebServer.Server.Responses
{
    using System.Text;
    using WebServer.Server.Common;
    using WebServer.Server.Http;

    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string text, string contentType) : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);

            var contentLenght = Encoding.UTF8.GetByteCount(text).ToString();

            this.Headers.Add("Content-Type", contentType);
            this.Headers.Add("Content-Lenght", contentLenght);

            this.Content = text;
        }
    }
}
