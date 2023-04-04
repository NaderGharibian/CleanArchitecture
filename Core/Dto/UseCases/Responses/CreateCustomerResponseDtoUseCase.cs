using Core.Dto.Contents;
using Core.Dto.Enums;

namespace Core.Dto.UseCases.Responses;

public class CreateCustomerResponseDtoUseCase : ResponseContentResult
{
    public CustomerContent Customer { get; }
    public CreateCustomerResponseDtoUseCase(StatusCode result, ResponseMessage message ) : base(result, message) { }
    public CreateCustomerResponseDtoUseCase(CustomerContent customer, StatusCode result, ResponseMessage message ) : base(result, message)
    {
        Customer = customer;
    }
}