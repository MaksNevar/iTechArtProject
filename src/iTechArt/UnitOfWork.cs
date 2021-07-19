using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Common
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _dbContext;
        
        private readonly ILog _logger;

        private bool _disposed;

        private readonly Dictionary<Type, object> _repositories;

        private readonly Dictionary<Type, object> _entitiesToRepositories;
        
        public UnitOfWork(TContext context, ILog logger)
        {
            _dbContext = context;
            _logger = logger;

            _repositories = new Dictionary<Type, object>();
            _entitiesToRepositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TContext), out var repo))
            {
                return repo as IRepository<TEntity>;
            }

            if (_entitiesToRepositories.TryGetValue(typeof(TEntity), out repo))
            {
                RegisterRepository(repo as IRepository<TEntity>);

                return repo as IRepository<TEntity>;
            }

            RegisterRepository<TEntity>();

            return _repositories[typeof(TContext)] as IRepository<TEntity>;
        }

        private void RegisterRepository<TEntity>() where TEntity : class
        {
            var tempRepo = new Repository<TEntity>(_dbContext, _logger);

            RegisterRepository(tempRepo);
            _entitiesToRepositories.Add(typeof(TEntity), tempRepo);
        }

        private void RegisterRepository<TEntity>(IRepository<TEntity> repository) where TEntity : class
        {
            _repositories.Add(typeof(TContext), repository);
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

        public async void SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}