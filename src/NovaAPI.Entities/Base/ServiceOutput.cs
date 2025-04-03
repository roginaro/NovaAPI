namespace NovaAPI.Entities.Base
{
    public class ServiceOutput<T>
    {
        public bool Success { get => Errors == null || !Errors.Any(); }
        public string Message { get; set; }
        public T Data { get; set; }

        public IEnumerable<ErrorBase> Errors { get; set; }
    }
}
