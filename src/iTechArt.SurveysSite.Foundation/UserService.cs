using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Foundation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task<User> GetUserByNameAsync(string login)
        {
            var user = await _userManager.FindByNameAsync(login);

            return user;
        }
    }
}