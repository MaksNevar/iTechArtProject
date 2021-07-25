using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(UserDbContext dbContext, ILog logger)
            : base(dbContext, logger)
        {

        }
    }
}