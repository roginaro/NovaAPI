namespace NovaAPI.Entities.Base
{
    public class RepositoryOutput<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
