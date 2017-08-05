namespace BloodDonate.Services
{
    public class Result<T>
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public T data { get; set; }
    }

}