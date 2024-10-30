using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc2.Introduction.Models.Security
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
