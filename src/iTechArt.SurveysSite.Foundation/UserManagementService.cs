using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Foundation
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<User> _userManager;


        public UserManagementService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }
    }
}