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
    public class UpdateCustomerRequestUseCase : IUpdateCustomerRequestUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITestDBRepository _testDBRepository;

        public UpdateCustomerRequestUseCase(ICustomerRepository customerRepository, ITestDBRepository testDBRepository)
        {
            _testDBRepository = testDBRepository;
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(UpdateCustomerRequestDtoUseCase request, IResponseUseCase<UpdateCustomerResponseDtoUseCase> response)
        {
            if (request.Customer.Id == null)
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Id It should not be empty")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.FirstName))
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The First Name It should not be empty")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.LastName))
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Last Name It should not be empty")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.DateOfBirth))
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Date of birth It should not be empty")));
                return false;
            }
            if (!Utilities.IsValidDate(request.Customer.DateOfBirth))
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Date of birth is not valid")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.BankAccountNumber))
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The bank account number It should not be empty")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.Email))
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The email It should not be empty")));
                return false;
            }
            if (!Utilities.IsValidEmail(request.Customer.Email))
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.EMAIL_IS_NOT_VALID))));
                return false;
            }
            if (!Utilities.IsValidPhoneNumber(request.Customer.PhoneNumber))
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.PHONE_NUMBER_IS_NOT_VALID))));
                return false;
            }
            var user = _customerRepository.findByUniqeField(request.Customer.FirstName, request.Customer.LastName, request.Customer.DateOfBirth);
            if (user != null)
            {
                if (user.Id != request.Customer.Id)
                {
                    response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.CUSTOMR_IS_EXISTS))));
                    return false;
                }

            }
            var email = _customerRepository.findByEmail(request.Customer.Email);
            if (email != null)
            {
                if (email.Id != request.Customer.Id)
                {
                    response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.EMAIL_IS_EXISTS))));
                    return false;
                }
            }



            _customerRepository.Update(request.Customer);



            response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Successed, new(EnumHelper<Success>.GetDisplayValue(Success.SUCCESSFULLY_COMPLETED))));
            try
            {
                await _testDBRepository.TestDBSaveChangeAsync();
                return true;
            }
            catch (Exception ex)
            {
                response.Handle(new UpdateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.BUG_IN_THE_PROCESS))));
                return false;
            }


        }
    }
}
