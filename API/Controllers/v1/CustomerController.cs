using Core.Dto.Contracts;
using Core.Dto.UseCases.Requests;
using Core.Interfaces.UseCases;
using Core.UseCases.Requests;
using Core.UseCases.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1;


[Produces("application/json")]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICreateCustomerRequestUseCase _createCustomerRequestUseCase;
    private readonly CreateCustomerResponseUseCase _createCustomerResponseUseCase;

    private readonly IReadCustomerRequestUseCase _readCustomerRequestUseCase;
    private readonly ReadCustomerResponseUseCase _readCustomerResponseUseCase;

    private readonly IDeleteCustomerRequestUseCase _deleteCustomerRequestUseCase;
    private readonly DeleteCustomerResponseUseCase _deleteCustomerResponseUseCase;

    private readonly IUpdateCustomerRequestUseCase _updateCustomerRequestUseCase;
    private readonly UpdateCustomerResponseUseCase _updateCustomerResponseUseCase;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ICreateCustomerRequestUseCase"></param>
    public CustomerController(
        ICreateCustomerRequestUseCase createCustomerRequestUseCase,
        CreateCustomerResponseUseCase createCustomerResponseUseCase,

        IReadCustomerRequestUseCase readCustomerRequestUseCase,
         ReadCustomerResponseUseCase readCustomerResponseUseCase,

         IDeleteCustomerRequestUseCase deleteCustomerRequestUseCase,
         DeleteCustomerResponseUseCase deleteCustomerResponseUseCase,

         IUpdateCustomerRequestUseCase updateCustomerRequestUseCase,
         UpdateCustomerResponseUseCase updateCustomerResponseUseCase
        )
    {
        _createCustomerRequestUseCase = createCustomerRequestUseCase;
        _createCustomerResponseUseCase = createCustomerResponseUseCase;

        _readCustomerRequestUseCase = readCustomerRequestUseCase;
        _readCustomerResponseUseCase = readCustomerResponseUseCase;

        _deleteCustomerRequestUseCase = deleteCustomerRequestUseCase;
        _deleteCustomerResponseUseCase = deleteCustomerResponseUseCase;

        _updateCustomerRequestUseCase = updateCustomerRequestUseCase;
        _updateCustomerResponseUseCase = updateCustomerResponseUseCase;
    }

    /// <summary>
    /// This API should do create a customer" 
    /// </summary>
    /// <remarks> 
    /// ### **`FirstName`** FirstName It should not be empty
    /// ### **`LastName`** LastName It should not be empty
    /// ### **`Email`** Email It should not be empty
    /// ### **`PhoneNumber`** PhoneNumber It should not be empty
    /// ### **`DateOfBirth`** DateOfBirth It should not be empty
    /// ### **`BankAccountNumber`** BankAccountNumber It should not be empty
    ///  Response : success
    ///  
    ///           {
    ///           "Customer": null,
    ///           "StatusCode": 200,
    ///           "Message": {
    ///             "ShowType": "None",
    ///             "Text": "Successfully completed"
    ///           }
    ///         }
    /// </remarks>
    /// <returns></returns>
    [HttpPost(nameof(Create))]
    public async Task<ContentResult> Create([FromBody] CreateCustomerContract model)
    {
        await _createCustomerRequestUseCase.Handle(new CreateCustomerRequestDtoUseCase(model), _createCustomerResponseUseCase);
        return _createCustomerResponseUseCase.ContentResult;
    }



    /// <summary>
    /// This API should do read customers" 
    /// </summary>
    /// <remarks> 
    ///  Response : success
    ///  
    ///        {
    ///               "Customer": [
    ///                 {
    ///                   "Id": 1,
    ///                   "FirstName": "NADER",
    ///                   "LastName": "GHARIBIAN",
    ///                   "DateOfBirth": "1999-01-01",
    ///                   "PhoneNumber": "09163307425",
    ///                   "Email": "NADER@GMAIL.COM",
    ///                   "BankAccountNumber": "123"
    ///                 },
    ///                 {
    ///                   "Id": 2,
    ///                   "FirstName": "NADER1",
    ///                   "LastName": "GHARIBIAN",
    ///                   "DateOfBirth": "1999-01-01",
    ///                   "PhoneNumber": "09163307532",
    ///                   "Email": "NADERG@MAIL.COM",
    ///                   "BankAccountNumber": "f"
    ///                 }
    ///               ],
    ///               "StatusCode": 200,
    ///               "Message": {
    ///                 "ShowType": "None",
    ///                 "Text": "Successfully completed"
    ///               }
    ///             }
    ///        
    ///        
    ///        
    ///        
    ///        
    ///        
    ///        
    /// </remarks>
    /// 
    /// <returns></returns>
    [HttpGet(nameof(Read))]
    public async Task<ContentResult> Read()
    {
        await _readCustomerRequestUseCase.Handle(new ReadCustomerRequestDtoUseCase(), _readCustomerResponseUseCase);
        return _readCustomerResponseUseCase.ContentResult;
    }


    /// <summary>
    /// This API should do delete a customer" 
    /// </summary>
    /// <remarks> 
    /// ### **`Id`** Id It should not be empty
    /// 
    ///  Response : success
    ///  
    ///     {
    ///      "StatusCode": 200,
    ///      "Message": {
    ///        "ShowType": "None",
    ///        "Text": "Successfully completed"
    ///      }
    ///    }
    ///        
    ///        
    /// </remarks>
    /// 
    /// <returns></returns>
[HttpDelete(nameof(Delete))]
    public async Task<ContentResult> Delete([FromBody] DeleteCustomerContract model)
    {
        await _deleteCustomerRequestUseCase.Handle(new DeleteCustomerRequestDtoUseCase(model), _deleteCustomerResponseUseCase);
        return _deleteCustomerResponseUseCase.ContentResult;
    }

    /// <summary>
    /// This API should do update a customer" 
    /// </summary>
    /// <remarks> 
    /// ### **`Id`** Id It should not be empty
    /// ### **`FirstName`** FirstName It should not be empty
    /// ### **`LastName`** LastName It should not be empty
    /// ### **`Email`** Email It should not be empty
    /// ### **`PhoneNumber`** PhoneNumber It should not be empty
    /// ### **`DateOfBirth`** DateOfBirth It should not be empty
    /// ### **`BankAccountNumber`** BankAccountNumber It should not be empty
    /// 
    /// 
    ///  Response : success
    ///  
    ///     {
    ///      "StatusCode": 200,
    ///      "Message": {
    ///        "ShowType": "None",
    ///        "Text": "Successfully completed"
    ///      }
    ///    }
    ///        
    ///        
    /// </remarks>
    /// 
    /// <returns></returns>
    [HttpPost(nameof(Update))]
    public async Task<ContentResult> Update([FromBody] UpdateCustomerContract model)
    {
        await _updateCustomerRequestUseCase.Handle(new UpdateCustomerRequestDtoUseCase(model), _updateCustomerResponseUseCase);
        return _updateCustomerResponseUseCase.ContentResult;
    }

}