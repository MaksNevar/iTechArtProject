using System;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Foundation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;


        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public async Task<bool> SignInAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var result = await _signInManager.PasswordSignInAsync(login, password, false, false);

            return result.Succeeded;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(User user, string password)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var role = await _roleManager.FindByNameAsync(RoleNames.UserRole);

            user.Role = role;
            var result = await _userManager.CreateAsync(user, password);

            return result;
        }
    }
}