using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface IUserManagementService
    {
        Task<User> GetUserByUsernameAsync(string userName);
    }
}