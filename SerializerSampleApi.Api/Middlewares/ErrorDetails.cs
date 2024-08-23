using System.Net;

namespace SerializerSampleApi.Api.Middlewares;

public class ErrorDetails
{
    public ErrorDetails(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
    }

    public int StatusCode { get; }
    public string Message { get; }
}