using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Foundation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;


        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public async Task<bool> SignInAsync(string login, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(login, password, false, false);

            return result.Succeeded;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public async Task<IdentityResult> CreateUserAsync(string userName, string email, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var failedResult = IdentityResult.Failed(new IdentityError
                {
                    Code = "1",
                    Description = "User already exists"
                });

                return failedResult;
            }

            var role = await _roleManager.FindByNameAsync("User");
            user = new User
            {
                UserName = userName,
                Email = email,
                Role = role
            };

            var result = await _userManager.CreateAsync(user, password);

            return result;
        }
    }
}