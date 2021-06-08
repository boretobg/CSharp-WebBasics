namespace WebServer
{
    using System.Threading.Tasks;
    using WebServer.Server;

    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
            .MapGet<HomeController>("/", c => c.Index()));
    }
}
