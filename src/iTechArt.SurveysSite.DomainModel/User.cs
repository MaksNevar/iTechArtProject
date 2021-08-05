namespace iTechArt.SurveysSite.DomainModel
{
    public class User
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string NormalizedUserName { get; set; }
    }
}