using System.ComponentModel.DataAnnotations;

namespace Project1ScopeIndia.Models
{
    public class RegistrationModel
    {

        public int? Id { get; set; }


        [Required(ErrorMessage = "Please enter your first name")]
        [DataType(DataType.Text)]
        public string RegFirstName { get; set; }


        [Required(ErrorMessage = "Please enter your last name")]
        [DataType(DataType.Text)]
        public string RegLastName { get; set; }


        [Required(ErrorMessage = "Please select your gender")]
        [DataType(DataType.Text)]
        public string RegGender { get; set; }


        [Required(ErrorMessage = "Please enter your date of birth")]
        [DataType(DataType.Date)]
        public DateTime? RegDateOfBirth { get; set; }


        [Required(ErrorMessage = "Please enter your Email address")]
        [DataType(DataType.EmailAddress)]
        public string RegEmailAddress { get; set; }


        [Required(ErrorMessage = "Please enter your Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string RegPhoneNumber { get; set; }


        [Required(ErrorMessage ="Please selct your country")]
        public string RegCountry {  get; set; }


        [Required(ErrorMessage = "Please selct your state")]
        public string RegState { get; set; }


        [Required(ErrorMessage = "Please selct your city")]
        public string RegCity { get; set; }

        [Required(ErrorMessage = "Please select atleast one hobby")]
        public string[]? RegHobbiesList { get; set; }
        public string? RegHobbies { get; set; }


        [Required(ErrorMessage = "Please upload your avatar")]
        [DataType(DataType.Upload)]
        public IFormFile? RegAvatar { get; set; }
        public string? RegAvatarPath {  get; set; }

        public bool? RegIsVerified { get; set; }
        public string? RegPassword { get; set; }
        public int? RegCourseId { get; set; }

    }
}
