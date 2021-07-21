using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Common
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected readonly TContext _dbContext;
        
        protected readonly ILog _logger;

        private bool _disposed;

        protected readonly Dictionary<Type, object> _repositories;

        protected readonly Dictionary<Type, Type> _registeredRepositoryTypes;
        
        public UnitOfWork(TContext context, ILog logger)
        {
            _dbContext = context;
            _logger = logger;

            _repositories = new Dictionary<Type, object>();
            _registeredRepositoryTypes = new Dictionary<Type, Type>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var repo))
            {
                return (IRepository<TEntity>)repo;
            }

            if (_registeredRepositoryTypes.TryGetValue(typeof(TEntity), out var repoType))
            {
                RegisterRepository<TEntity>(repoType);

                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            return new Repository<TEntity>(_dbContext, _logger);
        }
        
        private void RegisterRepository<TEntity>(Type repositoryType) where TEntity : class
        {
            var repository = Activator.CreateInstance(repositoryType, _dbContext, _logger);

            _repositories.Add(typeof(TEntity), repository);
        }

        protected void RegisterRepositoryTypes<TEntity>(params Type[] types)
        {
            foreach (var type in types)
            {
               _registeredRepositoryTypes.Add(typeof(TEntity), type); 
            }
        }
        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        { 
            await _dbContext.SaveChangesAsync();
        }
    }
}