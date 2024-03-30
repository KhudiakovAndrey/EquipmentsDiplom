namespace Equipments.Api
{
    public class ApiResponse<T>
    {
        public bool IsSucces { get; set; }
        public int StatusCode { get; set; }
        public ErrorResponse Message { get; set; } = new ErrorResponse();
        public T Data { get; set; }
    }
}
