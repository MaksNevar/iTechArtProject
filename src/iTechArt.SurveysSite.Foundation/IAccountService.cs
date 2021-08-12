using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Foundation
{
    public interface IAccountService
    {
        Task<bool> SignInAsync(string login, string password);

        Task SignOutAsync();

        Task<IdentityResult> RegisterAsync(User user, string password);
    }
}