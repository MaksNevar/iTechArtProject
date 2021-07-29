using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public class SurveysSiteUnitOfWork : UnitOfWork<SurveysSiteDbContext>, ISurveysSiteUnitOfWork
    {
        public IRepository<User> UserRepository => GetRepository<User>();


        public SurveysSiteUnitOfWork(SurveysSiteDbContext context, ILog logger)
            : base(context, logger)
        {
            RegisterRepositoryType<User, Repository<User>>();
        }
    }
}