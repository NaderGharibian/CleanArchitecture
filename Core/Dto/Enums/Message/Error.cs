using System.ComponentModel.DataAnnotations;

namespace Core.Dto.Enums.Message
{

    public enum Error
    {
        [Display(Name = "Bug..")]
        BUG_IN_THE_PROCESS = 0,

        [Display(Name = "Email is not valid")]
        EMAIL_IS_NOT_VALID = 1,

        [Display(Name = "PhoneNumber is not valid")]
        PHONE_NUMBER_IS_NOT_VALID = 2,

        [Display(Name = "Customer is exist")]
        CUSTOMR_IS_EXISTS = 3,

        [Display(Name = "Email is exist")]
        EMAIL_IS_EXISTS = 4,
    }

}
