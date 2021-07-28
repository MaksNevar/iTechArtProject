using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}