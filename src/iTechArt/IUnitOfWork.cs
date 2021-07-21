using System;
using System.Threading.Tasks;

namespace iTechArt.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task SaveAsync();
    }
}