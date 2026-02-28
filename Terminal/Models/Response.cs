
namespace Terminal.Models;

internal enum ResponseStatus
{
    Success = 0,
    Failure = 1,
}

internal class Response
{
    public ResponseStatus Status { get; init; }
    public string? Message { get; init; }

    public static Response Failure(string message)
    {
        return new Response()
        {
            Status = ResponseStatus.Failure,
            Message = message,
        };
    }

    public static Response Success()
    {
        return new Response()
        {
            Status = ResponseStatus.Success,
        };
    }
}
