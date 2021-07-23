using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public class ButtonClickRepository : Repository<ButtonClicksCounter>
    {
        public ButtonClickRepository(ButtonClicksCounterDbContext context, ILog logger) 
            : base(context, logger)
        {

        }
    }
}