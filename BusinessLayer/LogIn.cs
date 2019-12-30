using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class LogIn
    {
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "EMAIL : ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User password is required.")]
        [Display(Name = "PASSWORD : ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "REMEMBER ME : ")]
        public bool RememberMe { get; set; }
    }
}
