using System.Collections.Generic;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using System.Threading.Tasks;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByNameAsync(string normalizedUserName);

        Task<IReadOnlyCollection<User>> GetAllUsersAsync();

        Task<List<string>> GetUserRoleNamesAsync(User user);
    }
}