namespace WebServer.Controllers
{
    using WebServer.Server.Controllers;
    using WebServer.Server.Http;

    public class CatsController : Controller
    {
        [HttpGet]
        public HttpResponse Create() => View();

        [HttpPost]
        public HttpResponse Save(string name, int age)
            => Text($"{name} - {age}");
    }
}
