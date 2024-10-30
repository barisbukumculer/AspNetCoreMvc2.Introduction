using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc2.Introduction.Models.Security
{
    public class ResetPasswordViewModel
    {
        public string Code { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewConfirmedPassword { get; set; }


    }
}
