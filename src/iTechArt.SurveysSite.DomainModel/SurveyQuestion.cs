namespace iTechArt.SurveysSite.DomainModel
{
    public class SurveyQuestion
    {
        public const int QuestionMaxLength = 50;
        public const int QuestionMinLength = 5;


        public int Id { get; set; }

        public string Title { get; set; }

        public QuestionType QuestionType { get; set; }

        public Survey Survey { get; set; }
    }
}