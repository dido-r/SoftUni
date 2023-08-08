using System.Net.Sockets;
using System.Text;

namespace WebServer.Server
{
    internal class HttpResponse
    {
        private readonly string responseBody;
        private readonly int responseBodyLenght;

        public HttpResponse()
        {
            responseBody = @"Hello, World!";
            responseBodyLenght = Encoding.UTF8.GetByteCount(responseBody);
        }

        public async Task Write(NetworkStream stream)
        {
            var response = @$"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {responseBodyLenght}

{responseBody}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(responseBytes);
        }
    }
}
