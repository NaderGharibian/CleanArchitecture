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
    public class CreateCustomerRequestUseCase : ICreateCustomerRequestUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITestDBRepository _testDBRepository;

        public CreateCustomerRequestUseCase(ICustomerRepository customerRepository, ITestDBRepository testDBRepository)
        {
            _testDBRepository = testDBRepository;
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(CreateCustomerRequestDtoUseCase request, IResponseUseCase<CreateCustomerResponseDtoUseCase> response)
        {
            if (string.IsNullOrEmpty(request.Customer.FirstName))
            {
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The First Name It should not be empty")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.LastName)){
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Last Name It should not be empty")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.DateOfBirth)){
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Date of birth It should not be empty")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.BankAccountNumber)){
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The bank account number It should not be empty")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.DateOfBirth))
            {
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Date of birth It should not be empty")));
                return false;
            }
            if (!Utilities.IsValidDate(request.Customer.DateOfBirth))
            {
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Date of birth is not valid")));
                return false;
            }
            if (string.IsNullOrEmpty(request.Customer.Email)){
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The email It should not be empty")));
                return false;
            }
            if (!Utilities.IsValidEmail(request.Customer.Email)) {
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.EMAIL_IS_NOT_VALID))));
                return false;
            }
            if (!Utilities.IsValidPhoneNumber(request.Customer.PhoneNumber)) {
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.PHONE_NUMBER_IS_NOT_VALID))));
                return false;
            }
            if (_customerRepository.findByUniqeField(request.Customer.FirstName, request.Customer.LastName, request.Customer.DateOfBirth) != null){
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.CUSTOMR_IS_EXISTS))));
                return false;
            }
            if (_customerRepository.findByEmail(request.Customer.Email) != null) {
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.EMAIL_IS_EXISTS))));
                return false;
            }



            _customerRepository.Create(request.Customer);



            response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Successed, new(EnumHelper<Success>.GetDisplayValue(Success.SUCCESSFULLY_COMPLETED))));
            try
            {
                await _testDBRepository.TestDBSaveChangeAsync();
                return true;
            }
            catch (Exception ex)
            {
                response.Handle(new CreateCustomerResponseDtoUseCase(StatusCode.Failed, new ResponseMessage(EnumHelper<Error>.GetDisplayValue(Error.BUG_IN_THE_PROCESS))));
                return false;
            }


        }
    }
}
