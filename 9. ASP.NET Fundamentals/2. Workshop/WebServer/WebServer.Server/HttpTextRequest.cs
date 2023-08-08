using System.Net.Sockets;
using System.Text;

namespace WebServer.Server
{
    internal class HttpTextRequest
    {
        private readonly int bufferLenght;
        private byte[] buffer;
        private StringBuilder requestBuilder;

        public HttpTextRequest()
        {
            bufferLenght = 1024;
            buffer = new byte[bufferLenght];
            requestBuilder = new StringBuilder();
        }

        public async Task<string> Read(NetworkStream stream)
        {
            while (stream.DataAvailable)
            {
                var readBytes = await stream.ReadAsync(buffer, 0, bufferLenght);
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, readBytes));
            }
            return requestBuilder.ToString();
        }
    }
}
