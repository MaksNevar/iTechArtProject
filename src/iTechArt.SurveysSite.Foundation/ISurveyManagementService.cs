using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface ISurveyManagementService
    {
        public Task CreateSurveyAsync(Survey survey);

        public Task<IReadOnlyCollection<Survey>> GetAllUserSurveysAsync(int userId);

        public Task<Survey> GetByIdAsync(int surveyId);

        public Task DeleteSurveyAsync(Survey survey);

        public Task UpdateSurveyAsync(Survey fromSurvey, Survey survey);
    }
}