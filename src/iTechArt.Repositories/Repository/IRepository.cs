using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(params object[] keyValues);

        void Create(TEntity item);

        void Update(TEntity item);

        void Delete(TEntity item);
    }
}