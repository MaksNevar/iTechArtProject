using iTechArt.Common;
using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.Repositories.DbContexts;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public class SurveysSiteUnitOfWork : UnitOfWork<SurveysSiteDbContext>, ISurveysSiteUnitOfWork
    {
        public SurveysSiteUnitOfWork(SurveysSiteDbContext context, ILog logger)
            : base(context, logger)
        {

        }
    }
}