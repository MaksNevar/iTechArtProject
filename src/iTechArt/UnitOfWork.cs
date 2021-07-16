using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _dbContext;

        private readonly ILogger _logger;

        private bool _disposed;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        
        public UnitOfWork(TContext context, ILogger logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public IRepository<TContext> GetRepository()
        {
            RegisterRepository();

            return _repositories[typeof(TContext)] as IRepository<TContext>;
        }

        private void RegisterRepository()
        {
            _repositories.TryAdd(typeof(TContext), new Repository<TContext>(_dbContext, _logger));
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