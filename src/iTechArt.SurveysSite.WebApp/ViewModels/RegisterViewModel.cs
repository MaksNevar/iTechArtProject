using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter login")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Login should be from 5 to 20 symbols")]
        [RegularExpression(@"\w*\d*", ErrorMessage = "Login can contain only letters and numbers")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [StringLength(35, MinimumLength = 10, ErrorMessage = "Email should be from 10 to 35 symbols")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password should be from 8 to 20 symbols")]
        [RegularExpression(@"\w*\d*", ErrorMessage = "Password can contain only letters and numbers")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password should be from 8 to 20 symbols")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}