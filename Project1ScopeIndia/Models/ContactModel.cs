using System.ComponentModel.DataAnnotations;

namespace Project1ScopeIndia.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [DataType(DataType.Text)]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Please enter your emailid")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }


        [Required(ErrorMessage = "Please enter subject of your mail")]
        [DataType(DataType.Text)]
        public string ContactSubject { get; set; }


        [Required(ErrorMessage = "Please enter your message")]
        [DataType(DataType.Text)]
        public string ContactMessage { get; set; }


    }
}
