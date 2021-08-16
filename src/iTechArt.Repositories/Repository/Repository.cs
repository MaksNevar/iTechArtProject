using iTechArt.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ILog _logger;


        protected DbContext DbContext { get;  }


        public Repository(DbContext context, ILog logger)
        {
            DbContext = context;
            _logger = logger;
        }


        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            _logger.LogDebug("Getting all instances of the entity");

            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(params object[] keyValues)
        {
            _logger.LogDebug("Getting an instance by key values");

            return await DbContext.Set<TEntity>().FindAsync(keyValues);
        }

        public void Create(TEntity item)
        {
            _logger.LogDebug("Creating a new object with repository");

            DbContext.Set<TEntity>().Add(item);
        }

        public void Update(TEntity item)
        {
            _logger.LogDebug($"Updating an object {item}");

            DbContext.Set<TEntity>().Update(item);
        }

        public void Delete(TEntity item)
        {
            _logger.LogDebug($"Trying to delete an object {item} from the db");

            DbContext.Set<TEntity>().Remove(item);
        }
    }
}