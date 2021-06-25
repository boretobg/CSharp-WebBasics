namespace Andreys.Controllers
{
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ProductsController : Controller
    {
        public HttpResponse Details() => View();

        [HttpPost]
        public HttpResponse Details(ProductDetailViewModel model)
        {
            return View();
        }

        public HttpResponse Add() => View();
    }
}
