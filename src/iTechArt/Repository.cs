using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly ILogger _logger;


        public Repository(DbContext context, ILogger logger)
        {
            _dbContext = context;
            _logger = logger;
        }


        public void Create(TEntity item)
        {
            _logger.LogInformation("Creating a new object with repository");

            _dbContext.Set<TEntity>().Add(item);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            _logger.LogInformation("Getting all instances of the entity");

            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(object id)
        {
            _logger.LogInformation($"Trying to find an object with id {id} in the db");

            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Delete(TEntity item)
        {
            _logger.LogInformation($"Trying to delete an object {item} from the db");

            _dbContext.Set<TEntity>().Remove(item);
        }

        public void Update(TEntity item)
        {
            _logger.LogInformation("Updating an object");

            _dbContext.Set<TEntity>().Update(item);
        }
    }
}