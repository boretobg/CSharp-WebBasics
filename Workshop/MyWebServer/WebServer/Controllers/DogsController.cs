namespace WebServer.Controllers
{
    using WebServer.Models;
    using WebServer.Server.Controllers;
    using WebServer.Server.Http;

    public class DogsController : Controller
    {
        [HttpGet]
        public HttpResponse Create() => View();

        [HttpPost]
        public HttpResponse Create(DogFormModel model)
            => Text($"Dog: {model.Name} - {model.Age} - {model.Breed}");
    }
}
