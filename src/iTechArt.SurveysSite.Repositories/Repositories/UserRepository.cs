using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    [UsedImplicitly]
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext, ILog logger)
            : base(dbContext, logger)
        {

        }


        public async Task<User> GetByNameAsync(string normalizedUserName)
        {
            var user = await DbContext.Set<User>()
                .SingleOrDefaultAsync(userToFind => userToFind.NormalizedUserName == normalizedUserName);

            return user;
        }
    }
}