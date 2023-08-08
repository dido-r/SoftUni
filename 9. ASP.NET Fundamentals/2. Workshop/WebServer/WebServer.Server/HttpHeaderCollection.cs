namespace WebServer.Server
{
    internal class HttpHeaderCollection
    {
        private readonly List<HttpHeader> _headers;

        public HttpHeaderCollection()
        {
            _headers = new();
        }

        internal void Add(HttpHeader header)
        {
            _headers.Add(header);
        }
    }
}
