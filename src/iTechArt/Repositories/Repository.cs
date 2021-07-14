using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace iTechArt.Repositories
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

        public IEnumerable<TEntity> GetAll()
        {
            logger.LogInformation("Getting all instances of the entity");

            return dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(object id)
        {
            logger.LogInformation($"Trying to find an object with id {id} in the db");

            return dbContext.Set<TEntity>().Find(id);
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