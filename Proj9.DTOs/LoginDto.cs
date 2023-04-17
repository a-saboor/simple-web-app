using System.ComponentModel.DataAnnotations;

namespace Proj9.DTOs
{
    public class LoginDto
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "The email address is required..!")]
        [EmailAddress(ErrorMessage = "Invalid Email Address..!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password is required..!")]
        [MinLength(2, ErrorMessage = "Invalid password..!")]
        public string Password { get; set; }
       
    }

}
