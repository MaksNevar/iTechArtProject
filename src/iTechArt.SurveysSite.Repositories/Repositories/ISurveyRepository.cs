using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        public Task<IReadOnlyCollection<Survey>> GetAllUserSurveysAsync(int userId);

        public Task<Survey> GetByIdAsync(int id);
    }
}