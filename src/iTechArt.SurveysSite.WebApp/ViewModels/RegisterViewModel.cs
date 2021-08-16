using System.ComponentModel.DataAnnotations;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter login")]
        [StringLength(User.MaxUserNameLength, MinimumLength = User.MinUserNameLength, ErrorMessage = "Login should be from 5 to 20 symbols")]
        [RegularExpression(@"\w*\d*", ErrorMessage = "Login can contain only letters and numbers")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [StringLength(User.MaxEmailLength, MinimumLength = User.MinEmailLength, ErrorMessage = "Email should be from 10 to 35 symbols")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(User.MaxPasswordLength, MinimumLength = User.MinPasswordLength, ErrorMessage = "Password should be from 8 to 20 symbols")]
        [RegularExpression(@"\w*\d*", ErrorMessage = "Password can contain only letters and numbers")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        [StringLength(User.MaxPasswordLength, MinimumLength = User.MinPasswordLength, ErrorMessage = "Confirm password should be from 8 to 20 symbols")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}