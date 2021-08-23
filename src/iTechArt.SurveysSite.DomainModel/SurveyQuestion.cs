namespace iTechArt.SurveysSite.DomainModel
{
    public class SurveyQuestion
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Survey Survey { get; set; }

        public string QuestionType { get; set; }
    }
}