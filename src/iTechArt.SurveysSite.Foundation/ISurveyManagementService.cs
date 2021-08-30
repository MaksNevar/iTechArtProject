using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface ISurveyManagementService
    {
        public Task CreateSurveyAsync(Survey survey);
    }
}