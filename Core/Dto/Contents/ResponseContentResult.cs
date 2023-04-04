using Core.Dto.Enums;

namespace Core.Dto.Contents;

public abstract class ResponseContentResult
{
    public StatusCode StatusCode { get; private set; }
    public ResponseMessage Message { get; private set; }
    protected ResponseContentResult(StatusCode statusCode, ResponseMessage message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}