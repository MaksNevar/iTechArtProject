namespace iTechArt.SurveysSite.DomainModel
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string NormalizedUserName { get; set; }
    }
}