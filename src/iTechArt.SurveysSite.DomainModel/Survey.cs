using System;
using System.Collections.Generic;

namespace iTechArt.SurveysSite.DomainModel
{
    public class Survey
    {
        public const int NameMaxLength = 50;
        public const int NameMinLength = 5;


        public int Id { get; set; }

        public string Title { get; set; }

        public User Owner { get; set; }

        public DateTime ChangeDate { get; set; }

        public List<SurveyQuestion> Questions { get; set; }
    }
}