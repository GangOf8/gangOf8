namespace HorseMoney.Domain.Common;

public class BaseResponse<T>
{
    public T? Data { get; set; }
    public Error Error { get; set; }

    public BaseResponse(T data)
    {
        Data = data;
        Error = Error.None;
    }

    public BaseResponse(Error error)
    {
        Data = default;
        Error = error;
    }
}