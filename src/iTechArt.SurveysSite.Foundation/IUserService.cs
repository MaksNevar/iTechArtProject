using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Foundation
{
    public interface IUserService
    {
        Task<bool> SignInAsync(string login, string password);

        Task SignOutAsync();

        Task<User> GetUserByUsernameAsync(string userName);

        Task<IdentityResult> CreateUserAsync(string userName, string email, string password);
    }
}