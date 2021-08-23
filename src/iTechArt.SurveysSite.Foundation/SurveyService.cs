using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveysSiteUnitOfWork _unitOfWork;


        public SurveyService(ISurveysSiteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task CreateSurveyAsync(User user, Survey survey)
        {
            _unitOfWork.GetRepository<Survey>().Create(survey);
            await _unitOfWork.SaveAsync();
        }
    }
}