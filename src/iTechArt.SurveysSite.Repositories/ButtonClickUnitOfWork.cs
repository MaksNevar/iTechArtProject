using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Repositories
{
    public class ButtonClickUnitOfWork : UnitOfWork<ButtonClicksCounterContext>, IButtonClickUnitOfWork
    {
        public ButtonClickRepository Repository => (ButtonClickRepository)GetRepository<ButtonClicksCounter>();


        public ButtonClickUnitOfWork(ButtonClicksCounterContext context, ILog logger)
            : base(context, logger)
        {
            RegisterRepositoryTypes<ButtonClicksCounter, ButtonClickRepository>();
        }
    }
}