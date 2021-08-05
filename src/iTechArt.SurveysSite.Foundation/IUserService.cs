using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface IUserService
    {
        Task<User> SignInAsync(string login, string password);

        Task SignOutAsync();

        Task<User> GetUserByNameAsync(string login);
    }
}