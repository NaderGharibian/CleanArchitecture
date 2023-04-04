using Core.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.Contracts
{
    public  class DeleteCustomerContract
    {
        [Required(ErrorMessage = "Id It should not be empty")]
        public int? Id { get; set; }

     


      
    }
}
