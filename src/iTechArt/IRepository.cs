using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}