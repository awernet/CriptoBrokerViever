namespace MexcApi.Responses
{
    public class ApiResponse<T>
    {
        public bool success { get; set; }
        public int code { get; set; }
        public T data { get; set; }
    }




}
