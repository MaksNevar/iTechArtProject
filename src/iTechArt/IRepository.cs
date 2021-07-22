using System.Linq;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.Common
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}