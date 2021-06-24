namespace Git.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class CommitsController : Controller
    {
        public HttpResponse All() => View();
    }
}
