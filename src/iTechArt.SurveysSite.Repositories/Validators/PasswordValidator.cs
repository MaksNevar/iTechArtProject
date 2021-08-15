using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Repositories
{
    public class PasswordValidator : IPasswordValidator<User>
    {
        
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password), "Password cannot be null");
            }

            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager), "User manager can't be null");
            }

            var errors = new List<IdentityError>();

            if (string.IsNullOrWhiteSpace(password) || password.Length < User.MinPasswordLength)
            {
                errors.Add(new IdentityError
                {
                    Code = "Short password",
                    Description = "Password is too short"
                });
            }

            if (password.Length > User.MaxPasswordLength)
            {
                errors.Add(new IdentityError
                {
                    Code = "Long password",
                    Description = "Password is too long"
                });
            }

            if (!password.Any(c => c >= '0' && c <= '9'))
            {
                errors.Add(new IdentityError
                {
                    Code = "Digit is required",
                    Description = "At least one digit is required"
                });
            }

            if (!password.Any(c => c >= 'a' && c <= 'z'))
            {
                errors.Add(new IdentityError
                {
                    Code = "Lowercase is required",
                    Description = "At least one lowercase letter is required"
                });
            }

            return Task.FromResult(errors.Count > 0 
                ? IdentityResult.Failed(errors.ToArray()) 
                : IdentityResult.Success);
        }
    }
}