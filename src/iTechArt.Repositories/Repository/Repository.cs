using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.Common;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repositories.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        private readonly ILog _logger;


        public Repository(DbContext context, ILog logger)
        {
            _dbContext = context;
            _logger = logger;
        }


        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            _logger.LogDebug("Getting all instances of the entity");

            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(params object[] keyValues)
        {
            _logger.LogDebug("Getting an instance by key values");

            return await _dbContext.Set<TEntity>().FindAsync(keyValues);
        }

        public void Create(TEntity item)
        {
            _logger.LogDebug("Creating a new object with repository");

            _dbContext.Set<TEntity>().Add(item);
        }

        public void Update(TEntity item)
        {
            _logger.LogDebug($"Updating an object {item}");

            _dbContext.Set<TEntity>().Update(item);
        }

        public void Delete(TEntity item)
        {
            _logger.LogDebug($"Trying to delete an object {item} from the db");

            _dbContext.Set<TEntity>().Remove(item);
        }
    }
}