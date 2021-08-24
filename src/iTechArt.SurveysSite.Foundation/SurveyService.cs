using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveysSiteUnitOfWork _unitOfWork;
        private readonly ILog _logger;


        public SurveyService(ISurveysSiteUnitOfWork unitOfWork, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task CreateSurveyAsync(User user, Survey survey)
        {
            survey.User = user;
            _unitOfWork.GetRepository<Survey>().Create(survey);
            await _unitOfWork.SaveAsync();

            _logger.LogDebug($"The survey {survey.Name} created by {user.UserName} on {survey.CreatingDate:MM/dd/yyyy}");
        }
    }
}