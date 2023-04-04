using Context.Tables;
using Core.Dto.Contents;
using Core.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.UseCases.Responses;

public class ReadCustomerResponseDtoUseCase : ResponseContentResult
{
    public List<TCustomer> Customer { get; }
    public ReadCustomerResponseDtoUseCase(StatusCode result, ResponseMessage message) : base(result, message) { }
    public ReadCustomerResponseDtoUseCase(List<TCustomer> customer, StatusCode result, ResponseMessage message) : base(result, message)
    {
        Customer = customer;
    }
}