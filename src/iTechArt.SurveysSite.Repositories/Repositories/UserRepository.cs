using System.Collections.Generic;
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

        public async Task<string> GetUserRoleAsync(User user)
        {
            var role = await DbContext.Set<Role>()
                .SingleOrDefaultAsync(roleToFind => roleToFind.Users.Contains(user));

            return role.Name;
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var users = DbContext.Set<User>().Include(user => user.Role).AsNoTracking();

            return await users.ToListAsync();
        }
    }
}