namespace Books.Api.Responses
{
    public class Response <T> where T : class
    {
        public string MyProperty { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public List<T> Data { get; set; }

    }
}
