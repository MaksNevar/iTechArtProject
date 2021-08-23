using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface ISurveyService
    {
        public Task CreateSurveyAsync(User user, Survey survey);
    }
}