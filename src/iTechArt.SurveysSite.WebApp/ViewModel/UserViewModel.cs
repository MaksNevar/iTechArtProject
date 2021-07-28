using System.Collections.Generic;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.WebApp.ViewModel
{
    public class UserViewModel
    {
        public IReadOnlyCollection<User> Users { get; set; }
    }
}