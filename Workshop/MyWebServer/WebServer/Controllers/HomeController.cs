namespace WebServer.Controllers
{
    using WebServer.Server.Controllers;
    using WebServer.Server.Http;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) : base(request)
        {
        }

        public HttpResponse Index() => Text("Hellp from Bobby!");
        public HttpResponse LocalRedirect() => Redirect("/Cats");
        public HttpResponse ToSoftuni() => Redirect("https://softuni.bg");
    }
}
