using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(DbContext context, ILog logger) 
            : base(context, logger)
        {

        }


        public async Task<IReadOnlyCollection<Survey>> GetAllUserSurveysAsync(int userId)
        {
            var surveys = await DbContext.Set<Survey>()
                .Where(survey => survey.Owner.Id == userId)
                .ToListAsync();

            return surveys;
        }

        public async Task<Survey> GetByIdAsync(int id)
        {
            var survey = await DbContext.Set<Survey>()
                .Include(s => s.Owner)
                .SingleOrDefaultAsync(s => s.Id == id);

            return survey;
        }
    }
}