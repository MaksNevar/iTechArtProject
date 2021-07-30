using System.Linq;
using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext, ILog logger)
            : base(dbContext, logger)
        {

        }

        public async Task<User> GetByNameAsync(string name)
        {
            var userList = await GetAllAsync();

            var user = userList.SingleOrDefault(userToFind => userToFind.UserName.Equals(name));

            return await Task.FromResult(user);
        }
    }
}