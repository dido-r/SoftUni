namespace WebServer.Server
{
    internal class HttpHeader
    {
        public string Name { get; init; }
        public string Value { get; init; }

        public HttpHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
