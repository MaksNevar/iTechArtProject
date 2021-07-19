using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly ILog _logger;


        public Repository(DbContext context, ILog logger)
        {
            _dbContext = context;
            _logger = logger;
        }


        public void Create(TEntity item)
        {
            _logger.Log(LogLevel.Information, new Exception(), "Creating a new object with repository");

            _dbContext.Set<TEntity>().Add(item);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            _logger.Log(LogLevel.Information, new Exception(), "Getting all instances of the entity");

            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            _logger.Log(LogLevel.Information, new Exception(), $"Trying to find an object with id {id} in the db");

            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Delete(TEntity item)
        {
            _logger.Log(LogLevel.Information, new Exception(), $"Trying to delete an object {item} from the db");

            _dbContext.Set<TEntity>().Remove(item);
        }

        public void Update(TEntity item)
        {
            _logger.Log(LogLevel.Information, new Exception(), $"Updating an object {item}");

            _dbContext.Set<TEntity>().Update(item);
        }
    }
}