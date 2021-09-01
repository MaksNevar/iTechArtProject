using System.ComponentModel.DataAnnotations;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class SurveyQuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(SurveyQuestion.QuestionMaxLength, ErrorMessage = "The question title is too big")]
        [MinLength(SurveyQuestion.QuestionMinLength, ErrorMessage = "The question title is too small")]
        public string Title { get; set; }

        public QuestionType QuestionType { get; set; }
    }
}