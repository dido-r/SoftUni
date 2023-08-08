using System.Net;
using System.Net.Sockets;

namespace WebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ip;
        private readonly TcpListener listener;

        public HttpServer(string ip, int port)
        {
            this.ip = IPAddress.Parse(ip);
            listener = new(this.ip, port);
        }

        public async Task Start()
        {
            listener.Start();

            while (true)
            {
                var connection = await listener.AcceptTcpClientAsync();
                var stream = connection.GetStream();

                var request = new HttpTextRequest();
                var textRequest = await request.Read(stream);
                var httpRequest = HttpRequest.Init(textRequest);
                Console.WriteLine(textRequest);

                var response = new HttpResponse();
                await response.Write(stream);

                connection.Close();
            }
        }
    }
}