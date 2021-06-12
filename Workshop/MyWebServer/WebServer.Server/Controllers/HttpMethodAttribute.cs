namespace WebServer.Server.Controllers
{
    using System;
    using WebServer.Server.Http;

    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {
        protected HttpMethodAttribute(HttpMethod httpMethod)
            => this.HttpMethod = httpMethod;

        public HttpMethod HttpMethod { get; }
    }
}
