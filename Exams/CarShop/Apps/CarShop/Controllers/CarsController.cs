namespace CarShop.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class CarsController : Controller
    {
        public HttpResponse All()
        {
            return View();
        }

        public HttpResponse Add()
        {
            return View();
        }
    }
}
