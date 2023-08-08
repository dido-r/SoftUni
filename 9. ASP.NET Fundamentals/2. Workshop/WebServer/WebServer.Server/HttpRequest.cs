namespace WebServer.Server
{
    internal class HttpRequest
    {
        private Method Method { get; init; }

        private string Path { get; init; }

        private HttpHeaderCollection Headers { get; init; }

        private string Body { get; init; }

        public static HttpRequest Init(string request)
        {
            var lines = request.Split('\n');
            var firstLineData = lines[0].Split(" ");
            var method = firstLineData[0];
            var path = firstLineData[1];
            var headerCollection = new HttpHeaderCollection();
            var headers = lines.Skip(1);

            foreach (var header in headers)
            {
                if (header.Length < 2)
                {
                    break;
                }

                var headerData = header.Split(":", 2);
                headerCollection.Add(new HttpHeader(headerData[0], headerData[1]));
            }

            var body = lines[^1];

            return new HttpRequest()
            {
                Method = MethodParse(method),
                Path = path,
                Headers = headerCollection,
                Body = body
            };
        }

        private static Method MethodParse(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => Method.GET,
                "POST" => Method.POST,
                "PUT" => Method.PUT,
                "DELETE" => Method.DELETE,
                _ => throw new NotImplementedException("Invalid method!"),
            };

        }
    }
}

