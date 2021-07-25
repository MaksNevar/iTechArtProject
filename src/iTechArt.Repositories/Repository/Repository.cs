using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.Common;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Repositories.Repository
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
            _logger.LogInformation($"Creating a new object {typeof(TEntity)} with repository");

            _dbContext.Set<TEntity>().Add(item);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            _logger.LogInformation($"Getting all instances of the {typeof(TEntity)} entity");

            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
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
            _logger.LogInformation($"Updating an object {item}");

            _dbContext.Set<TEntity>().Update(item);
        }
    }
}