using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public class UnitOfWork<TEntity> : IUnitOfWork where TEntity : class
    {
        private readonly DbContext _dbContext;

        private readonly ILogger _logger;

        private bool _disposed;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        
        public UnitOfWork(DbContext context, ILogger logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public IRepository<TEntity> GetRepository()
        {
            RegisterRepository();

            return _repositories[typeof(TEntity)] as IRepository<TEntity>;
        }

        private void RegisterRepository()
        {
            _repositories.TryAdd(typeof(TEntity), new Repository<TEntity>(_dbContext, _logger));
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

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }


    }
}