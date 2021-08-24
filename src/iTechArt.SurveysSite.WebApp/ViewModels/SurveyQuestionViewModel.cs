using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class SurveyQuestionViewModel
    {
        [Required]
        [Display(Name = "")]
        public string Description { get; set; }

        public string QuestionType { get; set; }

        public List<SurveyQuestionAnswerViewModel> Answers { get; set; }
    }
}