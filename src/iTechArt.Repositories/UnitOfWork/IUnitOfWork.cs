using System;
using System.Threading.Tasks;
using iTechArt.Repositories.Repository;

namespace iTechArt.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task SaveAsync();
    }
}