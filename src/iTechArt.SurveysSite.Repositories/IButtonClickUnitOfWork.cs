using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Repositories
{
    public interface IButtonClickUnitOfWork : IUnitOfWork
    {
        void Create(ButtonClicksCounter item);

        Task<ButtonClicksCounter> GetByIdAsync(object id);

        void Update(ButtonClicksCounter item);
    }
}