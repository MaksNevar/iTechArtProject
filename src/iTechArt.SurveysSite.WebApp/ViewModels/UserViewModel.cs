using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please enter login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}