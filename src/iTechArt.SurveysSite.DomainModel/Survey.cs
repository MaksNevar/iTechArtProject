namespace iTechArt.SurveysSite.DomainModel
{
    public class Survey
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User User { get; set; }
    }
}