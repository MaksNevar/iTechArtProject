using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(object id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}