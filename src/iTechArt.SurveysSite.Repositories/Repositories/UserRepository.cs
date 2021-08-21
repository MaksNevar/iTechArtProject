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
            var users = await DbContext.Set<User>()
                .Include(user => user.UserRoles)
                .ThenInclude(ur => ur.Role)
                .AsNoTracking()
                .ToListAsync();

            return users;
        }

        public async Task<List<string>> GetUserRoleNamesAsync(User user)
        {
            var roleNames = await DbContext.Set<User>()
                .Where(userToSelect => userToSelect.Id == user.Id)
                .SelectMany(userToSelect => userToSelect.UserRoles.Select(ur => ur.Role.Name))
                .ToListAsync();

            return roleNames;
        }
    }
}