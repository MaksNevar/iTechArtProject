﻿using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.DomainModel
{
    public sealed class ButtonClicksCounter : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int Clicks { get; set; }
    }
}