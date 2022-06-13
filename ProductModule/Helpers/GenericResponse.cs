namespace ProductModule.Helpers
{
    public class GenericResponse <T>
    {
        public T Data { get; set; }
        public string Messsage { get; set; }
        public bool Success { get; set; }
    }
}
