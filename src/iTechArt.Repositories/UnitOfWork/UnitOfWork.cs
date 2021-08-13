using iTechArt.Common;
using iTechArt.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _dbContext;
        private readonly ILog _logger;

        private readonly Dictionary<Type, object> _repositories;
        private readonly Dictionary<Type, Type> _registeredRepositoryTypes;
        private bool _isDisposed;


        protected UnitOfWork(TContext context, ILog logger)
        {
            _dbContext = context;
            _logger = logger;

            _repositories = new Dictionary<Type, object>();
            _registeredRepositoryTypes = new Dictionary<Type, Type>();
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);

            if (_repositories.TryGetValue(entityType, out var repository))
            {
                return (IRepository<TEntity>)repository;
            }

            repository = CreateRepository<TEntity>();
            _repositories.Add(entityType, repository);

            return (IRepository<TEntity>)repository;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _isDisposed = true;
        }

        protected void RegisterRepositoryType<TEntity, TRepository>() where TEntity : class
           where TRepository : IRepository<TEntity>
        {
            _registeredRepositoryTypes.Add(typeof(TEntity), typeof(TRepository));
        }


        private IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            if (!_registeredRepositoryTypes.TryGetValue(typeof(TEntity), out var repositoryType))
            {
                return new Repository<TEntity>(_dbContext, _logger);
            }

            var customRepository = Activator.CreateInstance(repositoryType, _dbContext, _logger);

            return (IRepository<TEntity>)customRepository;
        }
    }
}