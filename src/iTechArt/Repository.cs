using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace iTechArt.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;
        protected readonly ILogger logger;


        public Repository(DbContext context, ILogger logger)
        {
            dbContext = context;
            this.logger = logger;
        }


        public void Create(TEntity item)
        {
            logger.LogInformation("Creating a new object with repository");
            dbContext.Set<TEntity>().Add(item);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            logger.LogInformation("Getting all instances of the entity");

            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(object id)
        {
            logger.LogInformation($"Trying to find an object with id {id} in the db");

            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Delete(TEntity item)
        {
            logger.LogInformation($"Trying to delete an object {item} from the db");
            dbContext.Set<TEntity>().Remove(item);
        }

        public void Update(TEntity item)
        {
            logger.LogInformation("Updating an object");

            dbContext.Set<TEntity>().Update(item);
        }
    }
}