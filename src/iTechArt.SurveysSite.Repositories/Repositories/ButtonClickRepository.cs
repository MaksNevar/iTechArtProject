using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    [UsedImplicitly]
    public class ButtonClickRepository : Repository<ButtonClicksCounter>, IButtonClickRepository
    {
        public ButtonClickRepository(DbContext context, ILog logger)
            : base(context, logger)
        {

        }


        public async Task<ButtonClicksCounter> GetButtonClicksAsync()
        {
            return await _dbContext.Set<ButtonClicksCounter>().SingleOrDefaultAsync();
        }
    }
}