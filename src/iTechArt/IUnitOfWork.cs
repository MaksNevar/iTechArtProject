using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Common
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void SaveAsync();
    }
}