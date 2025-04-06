using System.ComponentModel.DataAnnotations;

namespace Login_registration_page.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "First name is required to proceed.")]
        [MaxLength(20, ErrorMessage = "Max 30 characters allowed.")]
        public string firstName { get; set; }
        [MaxLength(20, ErrorMessage = "Max 30 characters allowed.")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Email is required to proceed.")]
        [MaxLength(20, ErrorMessage = "Max 50 characters allowed.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter a password to proceed.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength=8, ErrorMessage = "The password lenth should be between 8-20 characters long.")]
        public string password { get; set; }
        [Required(ErrorMessage = "Confirm password.")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="Passwords don't match.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed.")]
        public string confirmPassword { get; set; }
        [Required(ErrorMessage = "Username is required to proceed.")]
        [MaxLength(20, ErrorMessage = "Max 10 characters allowed.")]
        public string userName { get; set; }
    }
}
