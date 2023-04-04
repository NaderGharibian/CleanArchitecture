using Core.Dto.Contracts;
using Core.Dto.UseCases.Responses;
using Core.Interfaces;

namespace Core.Dto.UseCases.Requests;

    public class UpdateCustomerRequestDtoUseCase : IRequestUseCase<CreateCustomerResponseDtoUseCase>
    {
        public UpdateCustomerContract Customer { get; }

        public UpdateCustomerRequestDtoUseCase(UpdateCustomerContract customer)
        {
            Customer = customer;
        }
    }

