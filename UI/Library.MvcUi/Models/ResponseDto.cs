using Newtonsoft.Json;


namespace Library.MvcUi.Models;

public class ResponseDto<T>
{
    public T Data { get;  set; }
    public int StatusCode { get;  set; }
    public List<string> Errors { get; set; }
}