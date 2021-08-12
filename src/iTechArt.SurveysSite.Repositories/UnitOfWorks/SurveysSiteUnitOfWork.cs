using iTechArt.Common;
using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;
using iTechArt.SurveysSite.Repositories.Repositories;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public class SurveysSiteUnitOfWork : UnitOfWork<SurveysSiteDbContext>, ISurveysSiteUnitOfWork
    {
        public IUserRepository UserRepository => (IUserRepository)GetRepository<User>();
        public IRoleRepository RoleRepository => (IRoleRepository)GetRepository<Role>();


        public SurveysSiteUnitOfWork(SurveysSiteDbContext context, ILog logger)
            : base(context, logger)
        {
            RegisterRepositoryType<User, UserRepository>();
            RegisterRepositoryType<Role, RoleRepository>();
        }
    }
}