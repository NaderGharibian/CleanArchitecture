using Core.Dto.UseCases.Requests;
using Core.Dto.UseCases.Responses;


namespace Core.Interfaces.UseCases
{
    public interface IUpdateCustomerRequestUseCase : IRequestHandlerUseCase<UpdateCustomerRequestDtoUseCase, UpdateCustomerResponseDtoUseCase>
    {
    }
}