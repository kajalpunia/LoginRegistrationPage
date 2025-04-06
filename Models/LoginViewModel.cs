using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Login_registration_page.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username or Email is required to proceed.")]
        [DisplayName("UserName or Email")]
        [MaxLength(20, ErrorMessage = "Max 10 characters allowed.")]
        public string userNameorEmail { get; set; }

        [Required(ErrorMessage = "Enter a password to proceed.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password lenth should be between 8-20 characters long.")]
        public string password { get; set; }
    }
}
