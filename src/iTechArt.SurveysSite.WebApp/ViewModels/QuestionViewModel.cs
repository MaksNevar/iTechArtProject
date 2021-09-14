using System.ComponentModel.DataAnnotations;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(Question.QuestionMaxLength, ErrorMessage = "The question title is too big")]
        [MinLength(Question.QuestionMinLength, ErrorMessage = "The question title is too small")]
        public string QuestionTitle { get; set; }

        public QuestionType QuestionType { get; set; }
    }
}