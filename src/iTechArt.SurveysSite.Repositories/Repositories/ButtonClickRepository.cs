using System.Linq;
using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public class ButtonClickRepository : Repository<ButtonClicksCounter>, IButtonClickRepository
    {
        public ButtonClickRepository(ButtonClicksCounterDbContext context, ILog logger)
            : base(context, logger)
        {

        }


        public async Task<ButtonClicksCounter> GetButtonClicksAsync()
        {
            return (await GetAllAsync()).SingleOrDefault();
        }
    }
}