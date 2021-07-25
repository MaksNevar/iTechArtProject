using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<User>> GetAllUsersAsync();
        Task CreateUser(User userToCreate);
    }
}