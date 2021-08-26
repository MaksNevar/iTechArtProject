using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class SurveyManagementService : ISurveyManagementService
    {
        private readonly ISurveysSiteUnitOfWork _unitOfWork;
        private readonly ILog _logger;


        public SurveyManagementService(ISurveysSiteUnitOfWork unitOfWork, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task CreateSurveyAsync(Survey survey)
        {
            _unitOfWork.GetRepository<Survey>().Create(survey);
            await _unitOfWork.SaveAsync();

            _logger.LogDebug($"The survey {survey.Title} created by {survey.Owner.UserName} on {survey.ChangeDate:MM/dd/yyyy}");
        }
    }
}