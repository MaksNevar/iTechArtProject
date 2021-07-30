using System.Threading.Tasks;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public interface IButtonClickRepository : IRepository<ButtonClicksCounter>
    {
        Task<ButtonClicksCounter> GetButtonClicksAsync();
    }
}