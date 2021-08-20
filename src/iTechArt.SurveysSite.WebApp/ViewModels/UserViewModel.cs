using System;
using System.Collections.Generic;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> RoleNames { get; set; }

        public DateTime DateOfRegistration { get; set; }
    }
}