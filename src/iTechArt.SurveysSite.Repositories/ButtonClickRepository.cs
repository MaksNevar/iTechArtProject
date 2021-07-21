using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Repositories
{
    public class ButtonClickRepository : Repository<ButtonClicksCounter>, IButtonClickRepository
    {
        public ButtonClickRepository(ButtonClicksCounterContext context, ILog logger) 
            : base(context, logger)
        {

        }
    }
}