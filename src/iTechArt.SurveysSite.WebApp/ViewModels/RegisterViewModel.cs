﻿using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter login")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Login should be from 5 to 20 symbols")]
        [RegularExpression(@"\w\d", ErrorMessage = "Login can contain only letters and numbers")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password should be from 8 to 20 symbols")]
        [RegularExpression(@"\w\d", ErrorMessage = "Password can contain only letters and numbers")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        public string ConfirmPassword { get; set; }
    }
}