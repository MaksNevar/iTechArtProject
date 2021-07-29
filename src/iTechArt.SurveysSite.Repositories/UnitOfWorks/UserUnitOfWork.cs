using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public class UserUnitOfWork : UnitOfWork<UserDbContext>, IUserUnitOfWork
    {
        public IRepository<User> UserRepository => GetRepository<User>();


        public UserUnitOfWork(UserDbContext context, ILog logger)
            : base(context, logger)
        {
            RegisterRepositoryType<User, Repository<User>>();
        }
    }
}