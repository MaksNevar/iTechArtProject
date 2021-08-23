using System.Collections.Generic;

namespace iTechArt.SurveysSite.DomainModel
{
    public class Survey
    {
        public const int NameMaxLength = 50;
        public const int NameMinLength = 5;


        public int Id { get; set; }

        public string Name { get; set; }

        public User User { get; set; }

        public List<SurveyQuestion> SurveyQuestions { get; set; }
    }
}