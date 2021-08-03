using Microsoft.AspNet.Identity;

namespace iTechArt.SurveysSite.DomainModel
{
    public class User : IUser<int>
    {
        public int Id { get; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    }
}