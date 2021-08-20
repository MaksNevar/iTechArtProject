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
            var role = await DbContext.Set<Role>().SingleOrDefaultAsync(roleToFind => roleToFind.NormalizedName == normalizedName);

            return role;
        }

        public async Task<List<User>> GetUsersInRoleAsync(Role role)
        {
            var userRoles = DbContext.Set<User>()
                .Where(roleToSelect => roleToSelect.Id == role.Id)
                .SelectMany(roleToSelect => roleToSelect.UserRoles);
            var users = userRoles.Select(ur => ur.User);

            return await users.ToListAsync();
        }
    }
}