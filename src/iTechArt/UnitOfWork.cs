using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Common
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected readonly TContext _dbContext;
        protected readonly ILog _logger;

        protected readonly Dictionary<Type, object> _repositories;
        protected readonly Dictionary<Type, Type> _registeredRepositoryTypes;
        private bool _disposed;


        public UnitOfWork(TContext context, ILog logger)
        {
            _dbContext = context;
            _logger = logger;

            _repositories = new Dictionary<Type, object>();
            _registeredRepositoryTypes = new Dictionary<Type, Type>();
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var repo))
            {
                return (IRepository<TEntity>)repo;
            }

            if (_registeredRepositoryTypes.TryGetValue(typeof(TEntity), out var repoType))
            {
                var repository = Activator.CreateInstance(repoType, _dbContext, _logger);

                _repositories.Add(typeof(TEntity), repository);

                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            _repositories.Add(typeof(TEntity), new Repository<TEntity>(_dbContext, _logger));

            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
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


        protected void RegisterRepositoryTypes<TEntity, TRepo>() where TEntity : class, IEntity
           where TRepo : IRepository<TEntity>
        {
            _registeredRepositoryTypes.Add(typeof(TEntity), typeof(TRepo));
        }
    }
}