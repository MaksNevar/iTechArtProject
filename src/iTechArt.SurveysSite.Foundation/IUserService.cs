using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface IUserService
    {
        Task<bool> SignInAsync(string login, string password);

        Task SignOutAsync();

        Task<User> GetUserByNameAsync(string login);
    }
}