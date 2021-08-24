namespace iTechArt.SurveysSite.DomainModel
{
    public class SurveyQuestionAnswer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SurveyQuestion SurveyQuestion { get; set; }
    }
}