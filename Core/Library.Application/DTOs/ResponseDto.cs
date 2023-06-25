using System.Text.Json.Serialization;

namespace Library.Application.DTOs;

public class ResponseDto<T>
{
    public T Data { get; set; }

    public int StatusCode { get; set; }

    public List<string> Errors { get; set; }

    //static factory method
    public static ResponseDto<T> Success(T data, int statusCode)
    {
        return new ResponseDto<T> { Data = data, StatusCode = statusCode };
    }
    public static ResponseDto<T> Success(int statusCode)
    {
        return new ResponseDto<T> { Data = default, StatusCode = statusCode };
    }
    public static ResponseDto<T> Fail(List<string> errors, int statusCode)
    {
        return new ResponseDto<T>
        {
            Errors = errors,
            StatusCode = statusCode,
        };
    }
    public static ResponseDto<T> Fail(string error, int statusCode)
    {
        return new ResponseDto<T>
        {
            Errors = new List<string>() { error },
            StatusCode = statusCode
        };
    }
}