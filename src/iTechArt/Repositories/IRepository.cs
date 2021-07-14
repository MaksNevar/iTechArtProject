using System.Collections.Generic;

namespace iTechArt.Repositories
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}