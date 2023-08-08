using WebServer.Server;

namespace WebServer
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            var server = new HttpServer("127.0.0.1", 9090);
            await server.Start();
        }
    }
}