using Context.Interfaces;
using Core.Dto.Enums;
using Core.Dto.Enums.Message;
using Core.Dto.UseCases.Requests;
using Core.Dto.UseCases.Responses;
using Core.Helper;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;

namespace Core.UseCases.Requests
{
    internal class ReadCustomerRequestUseCase : IReadCustomerRequestUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public ReadCustomerRequestUseCase(ICustomerRepository customerRepository, ITestDBRepository testDBRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(ReadCustomerRequestDtoUseCase request, IResponseUseCase<ReadCustomerResponseDtoUseCase> response)
        {


            response.Handle(new ReadCustomerResponseDtoUseCase(_customerRepository.Read(), StatusCode.Successed, new(EnumHelper<Success>.GetDisplayValue(Success.SUCCESSFULLY_COMPLETED))));
            return true;


        }
    }
}
