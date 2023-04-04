using Core.Dto.Contracts;
using Core.Dto.UseCases.Responses;
using Core.Interfaces;

namespace Core.Dto.UseCases.Requests;

public class DeleteCustomerRequestDtoUseCase : IRequestUseCase<DeleteCustomerResponseDtoUseCase>
{

    public DeleteCustomerContract Customer { get; }

    public DeleteCustomerRequestDtoUseCase(DeleteCustomerContract customer)
    {
        Customer = customer;
    }
}
