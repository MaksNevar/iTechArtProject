using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Repositories
{
    public class UserValidator : IUserValidator<User>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<User> userManager, User user)
        {
            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager), "User manager can't be null");
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User can't be null");
            }

            var errors = new List<IdentityError>();
            var userName = await userManager.GetUserNameAsync(user);

            if (string.IsNullOrEmpty(userName))
            {
                errors.Add(new IdentityError
                {
                    Code = "Invalid name",
                    Description = "User name cannot be null"
                });
            }
            else
            {
                var owner = await userManager.FindByNameAsync(userName);

                if (owner != null &&
                    !string.Equals(await userManager.GetUserIdAsync(owner), await userManager.GetUserIdAsync(user)))
                {
                    errors.Add(new IdentityError
                    {
                        Code = "Duplicate name",
                        Description = "User with this username already exists"
                    });
                }
            }

            return errors.Count > 0 ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }
    }
}