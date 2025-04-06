using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Login_registration_page.Entities
{
    [Index(nameof(email), IsUnique =true)]
    [Index(nameof(userName), IsUnique = true)]
    public class UserAccount
    {
        [Key]
        public int userId { get; set; }
        [Required(ErrorMessage = "First name is required to proceed.")]
        [MaxLength(20, ErrorMessage ="Max 30 characters allowed.")]
        public string firstName { get; set; }
        [MaxLength(20, ErrorMessage = "Max 30 characters allowed.")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Email is required to proceed.")]
        [MaxLength(20, ErrorMessage = "Max 50 characters allowed.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter a password to proceed.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed.")]
        public string password { get; set; }
        [Required(ErrorMessage = "Username is required to proceed.")]
        [MaxLength(20, ErrorMessage = "Max 10 characters allowed.")]
        public string userName { get; set; }
    }
}
