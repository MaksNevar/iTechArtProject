using iTechArt.Repositories.Repository;
using System;
using System.Threading.Tasks;

namespace iTechArt.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task SaveAsync();
    }
}