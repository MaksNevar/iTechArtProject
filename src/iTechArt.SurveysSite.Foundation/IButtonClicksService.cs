using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Foundation
{
    public interface IButtonClicksService
    {
        Task IncrementButtonClicksAsync();

        Task<ButtonClicksCounter> GetButtonClicksAsync();
    }
}