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
            var users = DbContext.Set<User>().
                Include(user => user.UserRoles.Where(ur => ur.RoleId == role.Id))
                .AsNoTracking();

            return await users.ToListAsync();
        }
    }
}