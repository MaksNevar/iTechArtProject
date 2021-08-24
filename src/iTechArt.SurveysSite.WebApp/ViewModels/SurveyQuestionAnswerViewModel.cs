using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class SurveyQuestionAnswerViewModel
    {
        [Display(Name = "Choice")]
        public string Name { get; set; }
    }
}