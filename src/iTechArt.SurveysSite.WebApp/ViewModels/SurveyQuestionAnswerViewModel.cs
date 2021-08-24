using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class SurveyQuestionAnswerViewModel
    {
        [Required]
        [Display(Name = "")]
        public string Name { get; set; }
    }
}