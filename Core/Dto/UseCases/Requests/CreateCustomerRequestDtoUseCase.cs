using Core.Dto.Contracts;
using Core.Dto.UseCases.Responses;
using Core.Interfaces;

namespace Core.Dto.UseCases.Requests;

    public class CreateCustomerRequestDtoUseCase : IRequestUseCase<CreateCustomerResponseDtoUseCase>
    {
        public CreateCustomerContract Customer { get; }

        public CreateCustomerRequestDtoUseCase(CreateCustomerContract customer)
        {
            Customer = customer;
        }
    }

