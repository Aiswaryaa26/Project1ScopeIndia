using System.ComponentModel.DataAnnotations;

namespace Project1ScopeIndia.Models
{
    public class ConfirmPasswordModel
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessage = "Please re-enter your password to confirm")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage="Password and Confirm Password does'nt match")]
        public string ConfirmPassword { get; set; }

    }
}
