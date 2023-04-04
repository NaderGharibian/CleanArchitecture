using Context.Tables;
using Core.Dto.Contents;
using Core.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.UseCases.Responses;

public class DeleteCustomerResponseDtoUseCase : ResponseContentResult
{
    public DeleteCustomerResponseDtoUseCase(StatusCode result, ResponseMessage message) : base(result, message) { }
   
}