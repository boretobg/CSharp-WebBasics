namespace WebServer
{
    using System.Threading.Tasks;
    using WebServer.Controllers;
    using WebServer.Server;
    using WebServer.Server.Controllers;

    public class Startup
        {
            public static async Task Main()
                => await new HttpServer(routes => routes
                    .MapStaticFiles()
                    .MapControllers()
                    .MapGet<HomeController>("/ToCats", c => c.LocalRedirect()))
                .Start();
        }
  
}
