using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class SurveyViewModel
    {
        [Required]
        [MaxLength(Survey.NameMaxLength, ErrorMessage = "The title is too big")]
        [MinLength(Survey.NameMinLength, ErrorMessage = "The title is too small")]
        [Display(Name = "New survey name: ")]
        public string Name { get; set; }

        public List<SurveyQuestionViewModel> Questions { get; set; }
    }
}