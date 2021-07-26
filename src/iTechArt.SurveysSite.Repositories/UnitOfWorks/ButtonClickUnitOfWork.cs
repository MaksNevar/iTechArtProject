using iTechArt.Common;
using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;
using iTechArt.SurveysSite.Repositories.Repositories;

namespace iTechArt.SurveysSite.Repositories.UnitOfWorks
{
    public class ButtonClickUnitOfWork : UnitOfWork<ButtonClicksCounterDbContext>, IButtonClickUnitOfWork
    {
        public IButtonClickRepository ButtonClickRepository => (IButtonClickRepository)GetRepository<ButtonClicksCounter>();


        public ButtonClickUnitOfWork(ButtonClicksCounterDbContext context, ILog logger)
            : base(context, logger)
        {
            RegisterRepositoryType<ButtonClicksCounter, ButtonClickRepository>();
        }
    }
}