using System.ComponentModel.DataAnnotations;

namespace Project1ScopeIndia.Models
{
    public class LoginModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter your Emailid")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string UserEmailAddress { get; set; }


        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string UserPassword { get; set; }

        public bool UserRememberMe { get; set; }


    }
}
