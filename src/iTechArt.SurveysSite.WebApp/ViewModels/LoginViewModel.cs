using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter username")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}