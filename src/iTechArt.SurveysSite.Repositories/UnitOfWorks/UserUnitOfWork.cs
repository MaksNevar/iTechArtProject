using iTechArt.Common;
using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;
using iTechArt.SurveysSite.Repositories.Repositories;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public class UserUnitOfWork : UnitOfWork<UserDbContext>, IUserUnitOfWork
    {
        public UserRepository UserRepository => (UserRepository) GetRepository<User>();


        public UserUnitOfWork(UserDbContext context, ILog logger) 
            : base(context, logger)
        {
            RegisterRepositoryTypes<User, UserRepository>();
        }
    }
}