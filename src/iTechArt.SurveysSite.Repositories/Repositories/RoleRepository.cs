using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
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
    }
}