using System.ComponentModel.DataAnnotations;

namespace Core.Dto.Contracts
{
    public  class UpdateCustomerContract
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "First Name It should not be empty")]
        public string FirstName { get; set; }

        [StringLength(500, ErrorMessage = "Last Name Count Character {0} It's not over {1}")]
        [Required(ErrorMessage = "Last Name It should not be empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "DateOfBirth It should not be empty")]
        [StringLength(10, ErrorMessage = "Last Name Count Character {0} It's not over {1}")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number It should not be empty")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email It should not be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bank account number It should not be empty")]
        public string BankAccountNumber { get; set; }


      
    }
}
