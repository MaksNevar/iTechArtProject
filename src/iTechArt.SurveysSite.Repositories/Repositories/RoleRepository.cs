using System.Collections.Generic;
using System.Linq;
using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    [UsedImplicitly]
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context, ILog logger) : base(context, logger)
        {

        }


        public async Task<Role> GetRoleByNameAsync(string normalizedName)
        {
            var role = await DbContext.Set<Role>()
                .SingleOrDefaultAsync(roleToFind => roleToFind.NormalizedName == normalizedName);

            return role;
        }

        public async Task<IReadOnlyCollection<User>> GetUsersInRoleAsync(int roleId)
        {
            var users = await DbContext.Set<User>()
                .Where(roleToSelect => roleToSelect.Id == roleId)
                .SelectMany(roleToSelect => roleToSelect.UserRoles.Select(ur => ur.User))
                .ToListAsync();

            return users;
        }
    }
}