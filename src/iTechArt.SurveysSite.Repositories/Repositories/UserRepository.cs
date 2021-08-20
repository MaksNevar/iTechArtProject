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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext, ILog logger)
            : base(dbContext, logger)
        {

        }


        public async Task<User> GetUserByNameAsync(string normalizedUserName)
        {
            var user = await DbContext.Set<User>()
                .SingleOrDefaultAsync(userToFind => userToFind.NormalizedUserName == normalizedUserName);

            return user;
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var users = DbContext.Set<User>().
                Include(user => user.UserRoles)
                .ThenInclude(ur => ur.Role)
                .AsNoTracking();

            return await users.ToListAsync();
        }

        public async Task<List<string>> GetUserRoleNamesAsync(User user)
        {
            var userRoles = DbContext.Set<User>()
                .Where(userToSelect => userToSelect.Id == user.Id)
                .SelectMany(userToSelect => userToSelect.UserRoles);
            var roleNames = userRoles.Select(ur => ur.Role.Name);

            return await roleNames.ToListAsync();
        }
    }
}