using System;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RoleName { get; set; }

        public DateTime DateOfRegistration { get; set; }
    }
}