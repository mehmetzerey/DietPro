namespace Identity.Domain;

public class ServiceResponse<T> where T : class
{
    public bool IsSuccess { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;
    public T Data { get; set; }

}
public class ServiceResponse
{
    public bool IsSuccess { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;

}
