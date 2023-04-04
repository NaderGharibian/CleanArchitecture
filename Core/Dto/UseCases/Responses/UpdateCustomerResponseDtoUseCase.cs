using Core.Dto.Contents;
using Core.Dto.Enums;

namespace Core.Dto.UseCases.Responses;

public class UpdateCustomerResponseDtoUseCase : ResponseContentResult
{
    public CustomerContent Customer { get; }
    public UpdateCustomerResponseDtoUseCase(StatusCode result, ResponseMessage message ) : base(result, message) { }
    public UpdateCustomerResponseDtoUseCase(CustomerContent customer, StatusCode result, ResponseMessage message ) : base(result, message)
    {
        Customer = customer;
    }
}