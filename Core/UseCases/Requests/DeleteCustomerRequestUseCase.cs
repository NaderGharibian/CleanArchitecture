using Context.Interfaces;
using Core.Dto;
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
    internal class DeleteCustomerRequestUseCase : IDeleteCustomerRequestUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITestDBRepository _testDBRepository;

        public DeleteCustomerRequestUseCase(ICustomerRepository customerRepository, ITestDBRepository testDBRepository)
        {
            _testDBRepository = testDBRepository;
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(DeleteCustomerRequestDtoUseCase request, IResponseUseCase<DeleteCustomerResponseDtoUseCase> response)
        {
            if (request.Customer.Id==null)
            {
                response.Handle(new DeleteCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Id It should not be empty")));
                return false;
            }
          



            _customerRepository.Delete(request.Customer.Id.Value);



            response.Handle(new DeleteCustomerResponseDtoUseCase(StatusCode.Successed, new(EnumHelper<Success>.GetDisplayValue(Success.SUCCESSFULLY_COMPLETED))));
            try
            {
                await _testDBRepository.TestDBSaveChangeAsync();
                return true;
            }
            catch (Exception ex)
            {
                response.Handle(new DeleteCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.BUG_IN_THE_PROCESS))));
                return false;
            }


        }
    }
}
