using System.Collections.Generic;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using System.Threading.Tasks;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string normalizedName);

        Task<IReadOnlyCollection<User>> GetUsersInRoleAsync(int roleId);
    }
}